using NULL_API.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace NULL_API.Controllers
{
    public class CoolKidsClubController : ApiController
    {
        private static UserProfile UP1 = new UserProfile
        {
            Name        = "Rob Smith",
            Nickname    = "Smithy",
            Gender      = "Male",
            CurrentTown = "Milton Keynes",
            Email       = @"teamcoolkidsclub@gmail.com",
            PhoneNumber = 07123456789,
            DateOfBirth = new DateTime(1985, 4, 1),
            Occupation  = "Programmer",
            HomeTown    = "Milton Keynes",
            Languages   = new List<string> { "English" },
            Religion    = "None",
        };

        private static UserProfile UP2 = new UserProfile
        {
            Name = "Kevin Bacon",
            Nickname = "The Baconator",
            Gender = "Male",
            CurrentTown = "Holywood",
            Email = @"kevin.bacon@baconator.com",
            PhoneNumber = 07189312548,
            DateOfBirth = new DateTime(1958, 7, 8),
            Occupation = "Actor",
            HomeTown = "Philadelphia",
            Languages = new List<string> { "English" },
            Religion = "Christian",
        };

        private static UserProfile UP3 = new UserProfile
        {
            Name = "Jennifer Lawrence",
            Nickname = "J Law",
            Gender = "Female",
            CurrentTown = "Beverly Hills",
            Email = @"jlaw@talk21.com",
            PhoneNumber = 07531975364,
            DateOfBirth = new DateTime(1990, 8, 15),
            Occupation = "Actress",
            HomeTown = "Louisville",
            Languages = new List<string> { "English" },
            Religion = "Christian",
        };

        private static UserProfile UP4 = new UserProfile
        {
            Name = "Angela Merkel",
            Nickname = "Mutti",
            Gender = "Female",
            CurrentTown = "Munich",
            Email = @"mutti@germany.com",
            PhoneNumber = 07534876952,
            DateOfBirth = new DateTime(1954, 7, 17),
            Occupation = "Chancellor of Germany",
            HomeTown = "Hamberg",
            Languages = new List<string> { "English", "German" },
            Religion = "Lutheranism",
        };

        private static UserProfile UP5 = new UserProfile
        {
            Name = "Lewis Hamilton",
            Nickname = "Hambone",
            Gender = "Male",
            CurrentTown = "Monaco",
            Email = @"hambone@f1.com",
            PhoneNumber = 07125496378,
            DateOfBirth = new DateTime(1985, 4, 1),
            Occupation = "F1 Driver",
            HomeTown = "Stevenage",
            Languages = new List<string> { "English" },
            Religion = "None",
        };

        private static UserProfile UP6 = new UserProfile
        {
            Name = "Tifa Lockhart",
            Nickname = "Teef",
            Gender = "Female",
            CurrentTown = "Midgar",
            Email = @"tifa@avalanche.com",
            PhoneNumber = 07176385219,
            DateOfBirth = new DateTime(1997, 1, 31),
            Occupation = "Bartender",
            HomeTown = "Nibelheim",
            Languages = new List<string> { "English", "Japenese" },
            Religion = "None",
        };

        private static UserProfile UP7 = new UserProfile
        {
            Name = "Barry Allen",
            Nickname = "Flash",
            Gender = "Male",
            CurrentTown = "Central City",
            Email = @"flash@dc.com",
            PhoneNumber = 07468527639,
            DateOfBirth = new DateTime(1956, 10, 1),
            Occupation = "Criminal and Forensic Scientist",
            HomeTown = "Central City",
            Languages = new List<string> { "English" },
            Religion = "None",
        };

        private static UserProfile UP8 = new UserProfile
        {
            Name = "Maggie Green",
            Nickname = "Mags",
            Gender = "Female",
            CurrentTown = "Alexandria",
            Email = @"N/A",
            PhoneNumber = 07436974125,
            DateOfBirth = new DateTime(1982, 1, 7),
            Occupation = "Unemployed",
            HomeTown = "Unknown",
            Languages = new List<string> { "English" },
            Religion = "Christian",
        };

        private static UserProfile UP9 = new UserProfile
        {
            Name = "Anakin Skywalker",
            Nickname = "Darth Vader",
            Gender = "Male",
            CurrentTown = "Executor",
            Email = @"vader@empire.com",
            PhoneNumber = 07463879654,
            DateOfBirth = new DateTime(1977, 5, 25),
            Occupation = "Sith Lord",
            HomeTown = "Tatooine",
            Languages = new List<string> { "English" },
            Religion = "The Force",
        };

        private static UserProfile UP10 = new UserProfile
        {
            Name = "Carly Rae Jepsen",
            Nickname = "Cazza",
            Gender = "Female",
            CurrentTown = "Mission",
            Email = @"crj@hotmail.com",
            PhoneNumber = 07456387459,
            DateOfBirth = new DateTime(1985, 11, 21),
            Occupation = "",
            HomeTown = "Mission",
            Languages = new List<string> { "English" },
            Religion = "Christian",
        };

        private List<UserProfile> Profiles = new List<UserProfile>
        {
            UP1, UP2, UP3, UP4, UP5, UP6, UP7, UP8, UP9, UP10,
        };

        [SwaggerResponse(HttpStatusCode.OK, "A list of all Cool Kids Club users")]
        [Route(Routes.GetCKCUsers), HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                return Ok(Profiles);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [SwaggerResponse(HttpStatusCode.OK, "A list of Cool Kids Club users filtered by name")]
        [Route(Routes.GetCKCUserByName), HttpGet]
        public IHttpActionResult GetUserByName(string name)
        {
            try
            {
                List<UserProfile> profiles = Profiles.Where(q => q.Name == name).ToList();

                if (profiles.Count == 0)
                {
                    return BadRequest();
                }

                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [SwaggerResponse(HttpStatusCode.OK, "A list of Cool Kids Club users filtered by email")]
        [Route(Routes.GetCKCUserByEmail), HttpGet]
        public IHttpActionResult GetUserByEmail(string email)
        {
            try
            {
                List<UserProfile> profiles = Profiles.Where(q => q.Email == email).ToList();

                if (profiles.Count == 0)
                {
                    return BadRequest();
                }

                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [SwaggerResponse(HttpStatusCode.OK, "A list of Cool Kids Club users filtered by phone number")]
        [Route(Routes.GetCKCUserByPhoneNumber), HttpGet]
        public IHttpActionResult GetUserByPhoneNumber(string phoneNumber)
        {
            try
            {
                List<UserProfile> profiles = Profiles.Where(q => q.PhoneNumber == Convert.ToInt64(phoneNumber)).ToList();

                if (profiles.Count == 0)
                {
                    return BadRequest();
                }

                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}