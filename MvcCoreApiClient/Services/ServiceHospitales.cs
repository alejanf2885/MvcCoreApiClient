using MvcCoreApiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MvcCoreApiClient.Services
{
    public class ServiceHospitales
    {
        private string ApiUrl;
        private IConfiguration configuration;
        private MediaTypeWithQualityHeaderValue Header;

        public ServiceHospitales(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.ApiUrl = this.configuration.GetValue<string>("ApiUrls:ApiHospitales");
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Hospital>> GetHospitalsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/hospital";
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(json);
                    return hospitales;

                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<Hospital> FindHospitalAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/hospital/" + id;
                client.BaseAddress = new Uri(this.ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    
                    Hospital hospital = await response.Content.ReadAsAsync<Hospital>();
                    return hospital;

                }
                else
                {
                    return null;
                }
            }
        }
    }
}
