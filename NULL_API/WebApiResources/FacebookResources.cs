using System;
using System.Management.Instrumentation;
using NULL_API.Models;

namespace NULL_API.WebApiResources
{
    public class FacebookResources
    {
        public static UserProfile GetFacebookProfile(string user)
        {
            try
            {
                UserProfile profile = new UserProfile
                {
                    Name        = user,
                    Address     = "123 Fake Street.",
                    DateOfBirth = DateTime.UtcNow.AddYears(-25),
                };

                return profile;
            }
            catch (Exception ex)
            {
                throw new InstanceNotFoundException("Failed to find Facebook user profile", ex);
            }
        }
    }
}