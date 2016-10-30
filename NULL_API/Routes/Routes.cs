namespace NULL_API
{
    public class Routes
    {
        // Test Controller Routes
        public const string TestRoute                   = "api/test/Calculate/{num1}/{num2}";

        // Facebook Routes
        public const string GetFacebookUser             = "api/1/facebook/user/{name}";

        // Instagram Routes
        public const string GetInstagramUser            = "api/1/instagram/user/{name}";
        public const string SetupInstagram              = "api/1/instagram/setup";
        public const string CompleteInstagram           = "api/1/instagram/complete";

        // LinkedIn Routes
        public const string GetLinkedInUser             = "api/1/linkedin/user/{name}";

        // Cool Kids Club Routes
        public const string GetCKCUsers                 = "api/1/ckc/users";
        public const string GetCKCUserByName            = "api/1/ckc/user/name/{name}";
        public const string GetCKCUserByEmail           = "api/1/ckc/user/email/{email}";
        public const string GetCKCUserByPhoneNumber     = "api/1/ckc/user/phone_number/{phoneNumber}";
    }
}