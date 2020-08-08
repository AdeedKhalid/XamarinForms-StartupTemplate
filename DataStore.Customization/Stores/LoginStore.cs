using DataStore.Customization.Paths;
using DataStore.Customization.Requests;
using DataStore.Customization.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DataStore.Customization.Stores
{
    public class LoginStore
    {
        public async Task<List<TestResponseGET>> GetTestAsync()
        {
            try
            {
                var uri = ApiResources.Test_GETAPI;
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var itemResponse = JsonConvert.DeserializeObject<List<TestResponseGET>>(content);
                    return itemResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TestResponsePOST> PostTestAsync(TestRequestPOST item)
        {
            try
            {
                var uri = ApiResources.Test_POSTAPI;
                var json = JsonConvert.SerializeObject(item);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var response = await client.PostAsync(uri, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var itemResponse = JsonConvert.DeserializeObject<TestResponsePOST>(content);
                    return itemResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TestResponsePUT> PutTestAsync(int id, TestRequestPUT item)
        {
            try
            {
                var uri = ApiResources.Test_PUTAPI + id;
                var json = JsonConvert.SerializeObject(item);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var response = await client.PutAsync(uri, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var itemResponse = JsonConvert.DeserializeObject<TestResponsePUT>(content);
                    return itemResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TestResponseDELETE> DeleteTestAsync(int id)
        {
            try
            {
                var uri = ApiResources.Test_DELETEAPI + id;
                var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var itemResponse = JsonConvert.DeserializeObject<TestResponseDELETE>(content);
                    return itemResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
