using InstaSharp.Models.Responses;
using NULL_API.Models;
using System;
using System.Management.Instrumentation;

namespace NULL_API.WebApiResources
{
    public static class InstagramResources
    {
        public static OAuthResponse OAuthResponse { get; set; }

        public static UserProfile GetInstagramProfile(string user)
        {
            try
            {
                UserProfile profile = new UserProfile
                {
                    Name = user,
                    Address = "123 Fake Street.",
                    DateOfBirth = DateTime.UtcNow.AddYears(-25),
                };

                return profile;
            }
            catch (Exception ex)
            {
                throw new InstanceNotFoundException("Failed to find Instagram user profile", ex);
            }
        }
    }
}