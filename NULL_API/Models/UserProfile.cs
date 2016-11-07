using System;
using System.Collections.Generic;

namespace NULL_API.Models
{
    public class UserProfile
    {
        public string               Name;
        public string               Nickname;
        public string               Gender;
        public string               CurrentTown;
        public string               Email;
        public long                 PhoneNumber;
        public DateTime             DateOfBirth;
        public string               Occupation;
        public string               HomeTown;
        public List<string>         Languages;
        public string               Religion;
        public int                  MatchPercentage = 0;
        public string               Image;
        public ConnectedSocialMedia SocialMedia;
    }

    public class ConnectedSocialMedia
    {
        public string FacebookHandle;
        public string InstagramHandle;
        public string TwitterHandle;
    }
}