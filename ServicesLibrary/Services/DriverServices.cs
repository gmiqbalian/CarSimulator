﻿using Newtonsoft.Json;
using ServicesLibrary.Models;
using System.Net.Http.Headers;

namespace ServicesLibrary.Services
{
    public class DriverServices : IDriverServices
    {
        private DriverResponse? drivers { get; set; }
        public async void GetDriver()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://randomuser.me");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/?exc=login,location,registered,info,id,picture&noinfo");
            if(response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                drivers = JsonConvert.DeserializeObject<DriverResponse>(responseBody);
            }
        }
    }
}