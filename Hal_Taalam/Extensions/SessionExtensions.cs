using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text.Json;

namespace Hal_Taalam.Extensions
{
    public static class SessionExtensions
    {
        

        public static void SetObjectAsJson<T>(this ISession session,string Key,T Value) 
        {
            session.SetString(Key,JsonSerializer.Serialize(Value));
        }
        
        public static T GetOjectFromJson<T>(this ISession session,string key) 
        {
            var Value=session.GetString(key);
            return Value == null ? default : JsonSerializer.Deserialize<T>(Value);
        }
    }
}
