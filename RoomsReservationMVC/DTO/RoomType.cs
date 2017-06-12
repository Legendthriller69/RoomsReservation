using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NbAdults { get; set; }
        public int NbChildren { get; set; }
        public int NbSimpleBeds { get; set; }
        public int NbDoubleBeds { get; set; }
        public bool HasBalcon { get; set; }
        public bool ViewOnTheSea { get; set; }
        public decimal Price { get; set; }
    }
}
