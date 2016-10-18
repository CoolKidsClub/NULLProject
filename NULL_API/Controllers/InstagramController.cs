using InstaSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NULL_API.WebApiResources;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NULL_API.Controllers
{
    [SwaggerResponse(HttpStatusCode.InternalServerError, "An error has occured")]
    public class InstagramController : ApiController
    {
        private const string AccessTokenKey = "AccessToken";
        private const string UserIdKey = "User.Id";
        private const string UserUsernameKey = "User.Username";
        private const string UserFullNameKey = "User.FullName";
        private const string UserProfilePictureKey = "User.ProfilePicture";

        private readonly string ClientId = ConfigurationManager.AppSettings["instagram.clientId"];
        private readonly string ClientSecret = ConfigurationManager.AppSettings["instagram.clientSecret"];
        private readonly string RedirectUri = ConfigurationManager.AppSettings["instagram.redirectUri"];

        [SwaggerResponse(HttpStatusCode.OK, "Attached Instagram Profile")]
        [Route(Routes.GetInstagramUser), HttpGet]
        public async Task<IHttpActionResult> GetProfile(string name)
        {
            try
            {
                //var oauthResponse = HttpRuntime.Cache[OAuthCacheKey] as OAuthResponse;
                //if (oauthResponse == null)
                if (InstagramResources.OAuthResponse == null)
                {
                    return Setup();
                }

                var config = GetConfig();
                var users = new InstaSharp.Endpoints.Users(config, InstagramResources.OAuthResponse);
                var feed = await users.Feed(maxId: null, minId: null, count: null);

                return Ok(feed.Data);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route(Routes.SetupInstagram), HttpGet]
        public IHttpActionResult Setup()
        {
            try
            {
                var authLink = "https://api.instagram.com/oauth/authorize?"
                    + $"client_id={ClientId}"
                    + $"&redirect_uri={RedirectUri}"
                    + "&response_type=code";

                return Redirect(authLink);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route(Routes.CompleteInstagram), HttpGet]
        public IHttpActionResult Complete(string code)
        {
            try
            {
                var parameters = new NameValueCollection();
                parameters.Add("client_id", ClientId);
                parameters.Add("client_secret", ClientSecret);
                parameters.Add("grant_type", "authorization_code");
                parameters.Add("redirect_uri", RedirectUri);
                parameters.Add("code", code);

                var client = new WebClient();
                var result = client.UploadValues("https://api.instagram.com/oauth/access_token", "POST", parameters);
                var response = Encoding.Default.GetString(result);

                // deserializing nested JSON string to object
                var jsResult = (JObject)JsonConvert.DeserializeObject(response);
                string accessToken = (string)jsResult["access_token"];
                int id = (int)jsResult["user"]["id"];

                // Cache OAuth data
                HttpRuntime.Cache.Insert(AccessTokenKey, accessToken);
                HttpRuntime.Cache.Insert(UserIdKey, id);
                //var x = HttpContext.Current.Request.QueryString["access_token"];

                return Redirect("http://localhost:14406/");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private InstagramConfig GetConfig()
        {
            var clientId = ConfigurationManager.AppSettings["instagram.clientId"];
            var clientSecret = ConfigurationManager.AppSettings["instagram.clientSecret"];
            var redirectUri = ConfigurationManager.AppSettings["instagram.redirectUri"];
            var realtimeUri = "";

            return new InstagramConfig(clientId, clientSecret, redirectUri, realtimeUri);
        }
    }
}