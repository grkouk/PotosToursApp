using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PotosToursApp.Models;

namespace PotosToursApp.Services
{
    public class FacilitiesDataStore:IDataStore<Facility>
    {
        private const string BaseUrl = "http://grkoukdesktop/potosapi/api/facilities/";
        
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
    }
}
