using DataStore.Customization.Helpers;
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
                return await RequestProvider.GetAsync<List<TestResponseGET>>(uri);
            }
            catch (Exception ex)
            {
                return null;
                // Display Alert
            }
        }

        public async Task<TestResponsePOST> PostTestAsync(TestRequestPOST item)
        {
            try
            {
                var uri = ApiResources.Test_POSTAPI;
                return await RequestProvider.PostAsync<TestRequestPOST, TestResponsePOST>(uri, item);
            }
            catch (Exception ex)
            {
                return null;
                // Display Alert
            }
        }

        public async Task<TestResponsePUT> PutTestAsync(int id, TestRequestPUT item)
        {
            try
            {
                var uri = ApiResources.Test_PUTAPI + id;
                return await RequestProvider.PutAsync<TestRequestPUT, TestResponsePUT>(uri, item);
            }
            catch (Exception ex)
            {
                return null;
                // Display Alert
            }
        }

        public async Task<TestResponseDELETE> DeleteTestAsync(int id)
        {
            try
            {
                var uri = ApiResources.Test_DELETEAPI + id;
                return await RequestProvider.DeleteAsync<TestResponseDELETE>(uri);
            }
            catch (Exception ex)
            {
                return null;
                // Display Alert
            }
        }
    }
}
