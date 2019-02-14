using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace TPLClient.Helper
{
    public static class HttpClientHelper<T>where T : class
    {
        async static Task<T> ProcessURLAsync(string url, HttpClient client)
        {
            var Reponse = await client.GetStringAsync(url);
            return (T)Convert.ChangeType(Reponse, typeof(T));
        }
    }
}