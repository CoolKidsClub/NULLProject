using System;
using System.Collections.Generic;

namespace NULL_API.Models
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string HomeTown { get; set; }
        public List<string> Languages { get; set; }
        public string Religion { get; set; }
        public string ConnectedFacebookHandle { get; set; }
        public string ConnectedInstagramHandle { get; set; }
        public string ConnectedTwitterHandle { get; set; }
    }
}