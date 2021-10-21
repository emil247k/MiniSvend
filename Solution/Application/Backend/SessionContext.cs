using System;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Linq;

namespace SmartLock.Context
{
    public class SessionContext : ISessionContext
    {
        public HttpContext HttpContext {get; set;}

        public SessionContext(IHttpContextAccessor contextAccessor)
        {
            HttpContext = contextAccessor.HttpContext;
        }

        public string getToken(string key)
        {
            return String.Join("", HttpContext.Session.Get(key).Select(x=> String.Format("{0:x2}",x)));
        }

        public void SetToken(string key, string value)
        {
            HttpContext.Session.Set(key, Encoding.UTF8.GetBytes(value));
        }

        public void SetToken(string key, byte[] value)
        {
            HttpContext.Session.Set(key, value);
        }
        
        public void RemoveToken(string key)
        {
            HttpContext.Session.Remove(key);
        }
    }
}