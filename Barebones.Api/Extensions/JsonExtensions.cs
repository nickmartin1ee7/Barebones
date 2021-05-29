using System.Text;
using System.Text.Json;

namespace Barebones.Api.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj) => JsonSerializer.Serialize(obj);

        public static byte[] ToBytes(this string str) => Encoding.UTF8.GetBytes(str);
        
        public static string FromBytes(this byte[] bytes) => Encoding.UTF8.GetString(bytes);
        
        public static T FromJson<T>(this string json) => JsonSerializer.Deserialize<T>(json);
    }
}