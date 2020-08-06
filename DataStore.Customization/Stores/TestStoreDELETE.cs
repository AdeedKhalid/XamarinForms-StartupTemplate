using DataStore.Customization.Paths;
using DataStore.Customization.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Customization.Stores
{
    public class TestStoreDELETE
    {
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
