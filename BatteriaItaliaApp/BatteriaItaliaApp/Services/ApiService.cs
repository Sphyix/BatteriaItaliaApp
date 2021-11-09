using BatteriaItaliaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BatteriaItaliaApp.Services
{
    public class ApiService : IDataStore<WorkOrder>
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WorkOrder>> GetItemsAsync(bool boo)
        {
            var response = await _httpClient.GetAsync("Books");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<WorkOrder>>(responseAsString);
        }

        public async Task<WorkOrder> GetItemAsync(string id)
        {
            var response = await _httpClient.GetAsync($"Books/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WorkOrder>(responseAsString);
        }

        public async Task<bool> AddItemAsync(WorkOrder item)
        {
            var response = await _httpClient.PostAsync("Books",
                new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;

            //response.EnsureSuccessStatusCode();
        }

        public async Task<bool> UpdateItemAsync(WorkOrder item)
        {

            var response = await _httpClient.PutAsync($"Books?id={item.Id}",
                new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
           

            return response.IsSuccessStatusCode;

            //response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"Books/{id}");

            return response.IsSuccessStatusCode;

            //response.EnsureSuccessStatusCode();
        }
    }
}
