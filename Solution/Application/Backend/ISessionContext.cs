using Microsoft.AspNetCore.Http;

namespace SmartLock.Context
{
    public interface ISessionContext : IHttpContextAccessor
    {
        string getToken(string key);

        void SetToken(string key, string value);

        void SetToken(string key, byte[] value);
        
        void RemoveToken(string key);
    }
}