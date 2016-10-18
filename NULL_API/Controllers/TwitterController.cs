using NULL_API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NULL_API.Controllers
{
    public class TwitterController : ApiController
    {
        private UserProfile up1 = new UserProfile
        {
            Name = "Dave Gorman",
            Nickname = "Davey Boy",
            Gender = "Male",
            Address = "123 Fake Street",
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
            Address = "123 Real Street",
            Email = "fake@fake.com",
            DateOfBirth = DateTime.UtcNow,
            Occupation = "Success!",
            HomeTown = "Buuuuuurmingham",
            Languages = new List<string> { "French", "XML" },
            Religion = "Yes",
            MatchPercentage = 13,
        };

        [Route("api/1/twitter/user/handle/{twitterHandle}"), HttpGet]
        public IHttpActionResult GetTwitterProfileByHandle(string twitterHandle)
        {
            try
            {
                return Ok(up1);
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

                List<UserProfile> profiles = new List<UserProfile>();
                userData.MatchPercentage = 100;
                profiles.Add(up1);
                profiles.Add(up2);
                profiles.Add(userData);
                
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
