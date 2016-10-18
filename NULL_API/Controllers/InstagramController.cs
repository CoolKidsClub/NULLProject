using InstaSharp;
using NULL_API.WebApiResources;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace NULL_API.Controllers
{
    [SwaggerResponse(HttpStatusCode.InternalServerError, "An error has occured")]
    public class InstagramController : ApiController
    {
        //private const string OAuthCacheKey = "oauth";

        [SwaggerResponse(HttpStatusCode.OK, "Attached Instagram Profile")]
        [Route(Routes.GetInstagramUser), HttpGet]
        public async Task<IHttpActionResult> GetProfile(string name)
        {
            try
            {
                //var oauthResponse = HttpRuntime.Cache[OAuthCacheKey] as OAuthResponse;
                //if (oauthResponse == null)
                //{
                //    return Setup();
                //}

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
                var config = GetConfig();
                var scopes = new List<OAuth.Scope>();
                scopes.Add(OAuth.Scope.Likes);
                scopes.Add(OAuth.Scope.Comments);

                var link = OAuth.AuthLink(config.OAuthUri + "authorize", config.ClientId, config.RedirectUri, scopes, OAuth.ResponseType.Code);

                return Redirect(link);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route(Routes.CompleteInstagram), HttpGet]
        public async Task<IHttpActionResult> Complete(string code)
        {
            try
            {
                var config = GetConfig();
                var auth = new OAuth(config);
                InstagramResources.OAuthResponse = await auth.RequestToken(code);
                //HttpRuntime.Cache.Insert(OAuthCacheKey, oauth);
                return Redirect("http://localhost:14406/#/instagramForm");
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