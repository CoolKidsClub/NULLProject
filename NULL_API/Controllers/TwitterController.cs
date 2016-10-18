using NULL_API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NULL_API.Controllers
{
    public class TwitterController : ApiController
    {
        [Route("api/1/twitter/user/handle/{twitterHandle}"), HttpGet]
        public IHttpActionResult GetTwitterProfileByHandle(string twitterHandle)
        {
            try
            {
                UserProfile up = new UserProfile
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

                List<UserProfile> profiles = new List<UserProfile>();
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
