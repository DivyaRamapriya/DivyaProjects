using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace QuizApi.Utils
{
    public class CentralizedPrefixProvider : DefaultDirectRouteProvider
    {
        private readonly string _centralizedPrefix;

        public CentralizedPrefixProvider(string centralizedPrefix)
        {
            _centralizedPrefix = centralizedPrefix;
        }

        protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
        {
            var existingPrefix = base.GetRoutePrefix(controllerDescriptor);
            return existingPrefix == null ? _centralizedPrefix : $"{_centralizedPrefix}/{existingPrefix}";
        }
    }
}
