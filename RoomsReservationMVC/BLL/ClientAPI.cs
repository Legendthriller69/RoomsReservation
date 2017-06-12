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
    public class ClientAPI
    {
        private string uri = Info.uri + "Clients/";

        public List<Client> GetClients()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Client>>(response.Result);
            }
        }

        public Client GetClient(int id)
        {
            string uri2 = uri + id;
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri2);
                return JsonConvert.DeserializeObject<Client>(response.Result);
            }
        }

        public bool AddClient(Client c)
        {
            string url = uri;
            using (HttpClient client = new HttpClient())
            {
                string s1 = JsonConvert.SerializeObject(c);
                StringContent s = new StringContent(s1, Encoding.UTF8, "Application/json");

                Task<HttpResponseMessage> response = client.PostAsync(uri, s);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool EditClient(Client c)
        {
            string url = uri;
            using (var client = new HttpClient())
            {
                StringContent s = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = client.PutAsync(uri, s);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteClient(int id)
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
