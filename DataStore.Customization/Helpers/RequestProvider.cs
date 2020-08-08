using DataStore.Customization.Paths;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DataStore.Customization.Helpers
{
    public static class RequestProvider
    {
        public static async Task<TResult> GetAsync<TResult>(string uri, string authenticationToken = null)
        {
            TResult result = default;
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(authenticationToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TResult>(content);
                return result;
            }
            else
            {
                return result;
            }
        }

        public static async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string authenticationToken = null)
        {
            TResult result = default;
            var json = JsonConvert.SerializeObject(data);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(authenticationToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
            var response = await client.PostAsync(uri, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TResult>(content);
                return result;
            }
            else
            {
                return result;
            }
        }

        public static async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string authenticationToken = null)
        {
            TResult result = default;
            var json = JsonConvert.SerializeObject(data);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(authenticationToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
            var response = await client.PutAsync(uri, httpContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TResult>(content);
                return result;
            }
            else
            {
                return result;
            }
        }

        public static async Task<TResult> DeleteAsync<TResult>(string uri, string authenticationToken = null)
        {
            TResult result = default;
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(authenticationToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
            var response = await client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TResult>(content);
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
