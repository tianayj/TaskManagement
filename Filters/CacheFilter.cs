using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;

namespace TaskManager.Filters
{
    public class CacheFilter : ActionFilterAttribute
    {
        public int TimeDuration { get; set; }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try {
                actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
                {
                    MaxAge = TimeSpan.FromSeconds(TimeDuration),
                    MustRevalidate = true,
                    Public = true
                };
            }
            catch(NullReferenceException e)
            {
                Trace.WriteLine(e);
            }
        }
    }
}