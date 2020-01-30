using DataStore.Customization.Paths;
using DataStore.Customization.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Customization.Stores
{
    public class TestStoreGET
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
    }
}
