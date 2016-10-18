namespace NULL_API
{
    public class Routes
    {
        // Test Controller Routes
        public const string TestRoute = "api/test/Calculate/{num1}/{num2}";

        // Facebook Routes
        public const string GetFacebookUser = "api/1/facebook/user/{name}";

        // Instagram Routes
        public const string GetInstagramUser = "api/1/instagram/user/{name}";
        public const string SetupInstagram = "api/1/instagram/setup";
        public const string CompleteInstagram = "api/1/instagram/complete";

        // LinkedIn Routes
        public const string GetLinkedInUser = "api/1/linkedin/user/{name}";
    }
}