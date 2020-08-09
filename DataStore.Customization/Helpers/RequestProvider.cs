using DataStore.Customization.Paths;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace DataStore.Customization.Helpers
{
    public static class RequestProvider
    {
        private static CancellationTokenSource _cancellationTokenSource;

        private static CancellationToken GetCancellationToken()
        {
            _cancellationTokenSource = new CancellationTokenSource(10000);
            return _cancellationTokenSource.Token;
        }

        private static void DisposeCancellationToken() => 
            _cancellationTokenSource?.Dispose();

        public static async Task<TResult> GetAsync<TResult>(string uri, string authenticationToken = null)
        {
            TResult result = default;
            try
            {
                var client = new HttpClient();
                if (!string.IsNullOrWhiteSpace(authenticationToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
                var response = await client.GetAsync(uri, GetCancellationToken());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TResult>(content);
                    return result;
                }
                else
                    return result;
            }
            catch (Exception ex) { throw ex; }
            finally { DisposeCancellationToken(); }
        }

        public static async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data, string authenticationToken = null)
        {
            TResult result = default;
            try
            {
                var json = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var client = new HttpClient();
                if (!string.IsNullOrWhiteSpace(authenticationToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
                var response = await client.PostAsync(uri, httpContent, GetCancellationToken());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TResult>(content);
                    return result;
                }
                else
                    return result;
            }
            catch (Exception ex) { throw ex; }
            finally { DisposeCancellationToken(); }
        }

        public static async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data, string authenticationToken = null)
        {
            TResult result = default;
            try
            {
                var json = JsonConvert.SerializeObject(data);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var client = new HttpClient();
                if (!string.IsNullOrWhiteSpace(authenticationToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
                var response = await client.PutAsync(uri, httpContent, GetCancellationToken());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TResult>(content);
                    return result;
                }
                else
                    return result;
            }
            catch (Exception ex) { throw ex; }
            finally { DisposeCancellationToken(); }
        }

        public static async Task<TResult> DeleteAsync<TResult>(string uri, string authenticationToken = null)
        {
            TResult result = default;
            try
            {
                var client = new HttpClient();
                if (!string.IsNullOrWhiteSpace(authenticationToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationToken);
                var response = await client.DeleteAsync(uri, GetCancellationToken());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TResult>(content);
                    return result;
                }
                else
                    return result;
            }
            catch (Exception ex) { throw ex; }
            finally { DisposeCancellationToken(); }
        }
    }
}
