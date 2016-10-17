using NULL_API.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace NULL_API.Controllers
{
    public class TwitterController : ApiController
    {
        [Route("api/1/twitter/user/{twitterHandle}"), HttpGet]
        public IHttpActionResult GetTwitterProfile(string twitterHandle)
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
    }
}
