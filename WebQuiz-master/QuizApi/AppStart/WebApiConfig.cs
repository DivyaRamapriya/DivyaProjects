using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Newtonsoft.Json;
using QuizApi.Utils;

namespace QuizApi.AppStart
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Replace(typeof(IAssembliesResolver), new AssembliesResolver());
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            // Web API routes            
            config.MapHttpAttributeRoutes(new CentralizedPrefixProvider("api/v{version:int}"));            
        }

        private class AssembliesResolver : IAssembliesResolver
        {
            public ICollection<Assembly> GetAssemblies()
            {
                return new List<Assembly> { GetType().Assembly };
            }
        }
    }
}
