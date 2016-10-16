using System.Web.Http;
using System.Web.Http.Cors;

namespace NULL_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        public string Get()
        {
            return "This Route";
        }

        [Route(Routes.TestRoute), HttpGet]
        public string Calculate(int num1, int num2)
        {
            return (num1 + num2).ToString();
        }
    }
}
