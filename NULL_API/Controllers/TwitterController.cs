using NULL_API.Models;
using NULL_API.WebApiResources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NULL_API.Controllers
{
    public class TwitterController : ApiController
    {
        private readonly string ApiKey = ConfigurationManager.AppSettings["twitterApiKey"];
        private readonly string ApiSecret = ConfigurationManager.AppSettings["twitterApiSecret"];
        private readonly string AccessToken = ConfigurationManager.AppSettings["twitterAccessToken"];
        private readonly string AccessTokenSecret = ConfigurationManager.AppSettings["twitterAccessTokenSecret"];

        private UserProfile up1 = new UserProfile
        {
            Name = "Dave Gorman",
            Nickname = "Davey Boy",
            Gender = "Male",
            CurrentTown = "123 Fake Street",
            Email = "fake@fake.com",
            DateOfBirth = DateTime.UtcNow,
            Occupation = "Failure",
            HomeTown = "Landan Mate",
            Languages = new List<string> { "English", "German" },
            Religion = "Jedi Master",
            MatchPercentage = 43,
        };

        private UserProfile up2 = new UserProfile
        {
            Name = "Jennfier Garner",
            Nickname = "JG",
            Gender = "Female",
            CurrentTown = "123 Real Street",
            Email = "fake@fake.com",
            DateOfBirth = DateTime.UtcNow,
            Occupation = "Success!",
            HomeTown = "Buuuuuurmingham",
            Languages = new List<string> { "French", "XML" },
            Religion = "Yes",
            MatchPercentage = 13,
        };

        public TwitterController()
        {
            Tweetinvi.Auth.SetUserCredentials(ApiKey, ApiSecret, AccessToken, AccessTokenSecret);
        }

        [Route("api/1/twitter/user/handle/{twitterHandle}"), HttpGet]
        public IHttpActionResult GetTwitterProfileByHandle(string twitterHandle)
        {
            try
            {
                Tweetinvi.Models.IUser user = Tweetinvi.User.GetUserFromScreenName(twitterHandle);
                UserProfile up = new UserProfile
                {
                    Name = user.Name,
                    Nickname = user.ScreenName,
                    CurrentTown = user.Location,
                    Image = user.ProfileImageUrl400x400
                };

                return Ok(up);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("api/1/twitter/user/details"), HttpGet]
        public IHttpActionResult GetTwitterProfileByDetails(string userString)
        {
            try
            {
                UserProfile userData = new JavaScriptSerializer().Deserialize<UserProfile>(userString);

                // Build query. Search by full name, nickname, current town, home town, email
                var parameters = new string[]
                {
                    userData.Name,
                    userData.Nickname,
                    userData.CurrentTown,
                    userData.HomeTown,
                    userData.Email
                };
                var query = BuildQuery(parameters);
                var results = Search(query.ToString());
                return Ok(results);

                //var fullResults = new IEnumerable<UserProfile>[]
                //{
                //    Search(userData.Name),
                //    Search(userData.Nickname),
                //    Search(userData.CurrentTown),
                //    Search(userData.HomeTown)
                //};

                //var intersection = GetIntersection(fullResults);
                //if (intersection.Count > 0)
                //{
                //    return Ok(intersection);
                //}

                //var union = GetUnion(fullResults);
                //return Ok(union);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private string BuildQuery(params string[] parameters)
        {
            var query = new StringBuilder();

            foreach (var p in parameters)
            {
                if (!string.IsNullOrEmpty(p) && !string.IsNullOrWhiteSpace(p))
                {
                    query.Append(p);
                    query.Append(' ');
                }
            }

            return query.ToString();
        }

        private class UserProfileComparer : IEqualityComparer<UserProfile>
        {
            public bool Equals(UserProfile x, UserProfile y)
            {
                return x.Name == y.Name
                    && x.Nickname == y.Nickname
                    && x.Gender == y.Gender
                    && x.CurrentTown == y.CurrentTown
                    && x.Email == y.Email
                    && x.PhoneNumber == y.PhoneNumber
                    && x.DateOfBirth.Equals(y.DateOfBirth)
                    && x.Occupation == y.Occupation
                    && x.HomeTown == y.HomeTown
                    && x.Religion == y.Religion;
            }

            public int GetHashCode(UserProfile obj)
            {
                return obj.GetHashCode();
            }
        }

        private IList<UserProfile> GetUnion(params IEnumerable<UserProfile>[] results)
        {
            if (results.Length < 1)
            {
                // Return an empty list as there are no lists provided to intersect
                return new List<UserProfile>();
            }

            return results.SelectMany(x => x).Distinct().ToList();
        }

        private IList<UserProfile> GetIntersection(params IEnumerable<UserProfile>[] results)
        {
            if (results.Length < 1)
            {
                // Return an empty list as there are no lists provided to intersect
                return new List<UserProfile>();
            }

            var intersection = results
                .Skip(1)
                .Aggregate(new HashSet<UserProfile>(results.First()),
                           (l1, l2) => { l1.IntersectWith(l2); return l1; });
            return intersection.ToList();
        }

        private IEnumerable<UserProfile> Search(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm) && !string.IsNullOrWhiteSpace(searchTerm))
            {
                return Tweetinvi.Search.SearchUsers(searchTerm).Convert();
            }
            else
            {
                // Return an empty list as the search term is null/empty
                return new List<UserProfile>();
            }
        }
    }
}
