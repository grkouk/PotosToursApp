﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PotosToursApp.Models;

namespace PotosToursApp.Services
{
    public class FacilitiesDataStore:IDataStore<Facility>
    {
        private const string BaseUrl = "http://testapi.potos.tours/api/facilities/";
        
        public async Task<IEnumerable<Facility>> GetItemsAsync()
        {
            var httpClient = new HttpClient();

            try
            {
                var uri=new Uri(BaseUrl);
               
                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var facilitiesList = JsonConvert.DeserializeObject<List<Facility>>(jsonContent);
                    return facilitiesList;

                }
                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
                //throw;
            }
            
        }

        public async Task<bool> AddItemAsync(Facility item)
        {
            var httpClient = new HttpClient();
            var jsonFacility =  JsonConvert.SerializeObject(item);
            try
            {

                var uri = new Uri(BaseUrl);
                HttpContent httpContent = new StringContent(jsonFacility);
                httpContent.Headers.ContentType=new MediaTypeHeaderValue("application/json");
                httpClient.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.PostAsync(uri, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return await Task.FromResult(false);
                //throw;
            }
            return await Task.FromResult(false);

        }
    }
}
