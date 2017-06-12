using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class RentAPI
    {
        private string uri = Info.uri + "Rents/";

        public List<Rent> GetRents()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Rent>>(response.Result);
            }
        }

        public Rent GetRent(int id)
        {
            string uri2 = uri + id;
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri2);
                return JsonConvert.DeserializeObject<Rent>(response.Result);
            }
        }

        public bool AddRent(Rent r)
        {
            string url = uri;
            using (HttpClient client = new HttpClient())
            {
                string s1 = JsonConvert.SerializeObject(r);
                StringContent s = new StringContent(s1, Encoding.UTF8, "Application/json");

                Task<HttpResponseMessage> response = client.PostAsync(uri, s);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool EditRent(Rent r)
        {
            string url = uri;
            using (var client = new HttpClient())
            {
                StringContent s = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = client.PutAsync(uri, s);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteRent(int id)
        {
            string url = uri + id;
            using (HttpClient client = new HttpClient())
            {
                var response = client.DeleteAsync(url);
                return response.Result.IsSuccessStatusCode;
            }
        }
    }
}
