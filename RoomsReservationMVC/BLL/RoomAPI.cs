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
    public class RoomAPI
    {
        private string uri = Info.uri + "Rooms/";

        public List<Room> GetRooms()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Room>>(response.Result);
            }
        }

        public Room GetRoom(int id)
        {
            string uri2 = uri + id;
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri2);
                return JsonConvert.DeserializeObject<Room>(response.Result);
            }
        }

        public List<Room> GetRoomsByType(int id)
        {
            string uri2 = uri + "ByType/" + id;
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri2);
                return JsonConvert.DeserializeObject<List<Room>>(response.Result);
            }
        }

        public bool EditRoom(Room r)
        {
            string url = uri;
            using (var client = new HttpClient())
            {
                StringContent s = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = client.PutAsync(uri, s);
                return response.Result.IsSuccessStatusCode;
            }
        }
    }
}
