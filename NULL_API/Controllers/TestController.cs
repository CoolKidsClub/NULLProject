using System.Web.Http;

namespace NULL_API.Controllers
{
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
