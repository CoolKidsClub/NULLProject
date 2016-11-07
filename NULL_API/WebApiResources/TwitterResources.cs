using NULL_API.Models;
using System.Collections.Generic;

namespace NULL_API.WebApiResources
{
    public static class TwitterResources
    {
        public static IEnumerable<UserProfile> Convert(this IEnumerable<Tweetinvi.Models.IUser> twitterUsers)
        {
            var profiles = new List<UserProfile>();

            foreach (var user in twitterUsers)
            {
                var profile = new UserProfile
                {
                    Name = user.Name,
                    CurrentTown = user.Location,
                    Image = user.ProfileImageUrl400x400,
                    SocialMedia = new ConnectedSocialMedia { TwitterHandle = user.ScreenName }
                };

                profile.Languages = new List<string>();
                profile.Languages.Add(user.Language.ToString());

                profiles.Add(profile);
            }

            return profiles;
        }
    }
}