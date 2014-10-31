using System;
using Microsoft.AspNet.Mvc;
using System.IO;
using Microsoft.Framework.ConfigurationModel;
using System.Collections.Generic;

namespace MyMovies.Filters
{
    public class LogRequestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var logMessage = string.Format("{0} - User: {1}, Request-path: {2}", DateTime.Now.ToString(), context.HttpContext.User.Identity.Name, context.HttpContext.Request.Path);
            File.AppendAllLines(ReadPathToLogFileFromConfig(), new List<string> { logMessage });
        }


        private static string ReadPathToLogFileFromConfig()
        {
            var configuration = new Configuration();
            configuration.AddJsonFile("config.json");
            return configuration.Get("Log:File:Path");
        }
    }
}