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
    public class RoomTypeAPI
    {
        private string uri = Info.uri + "RoomTypes/";

        public List<RoomType> GetRoomTypes()
        {
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<RoomType>>(response.Result);
            }
        }

        public RoomType GetRoomType(int id)
        {
            string uri2 = uri + id;
            using (HttpClient client = new HttpClient())
            {
                Task<string> response = client.GetStringAsync(uri2);
                return JsonConvert.DeserializeObject<RoomType>(response.Result);
            }
        }
    }
}
