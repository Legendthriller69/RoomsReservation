using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Busy { get; set; }
        public RoomType RoomType { get; set; }
    }
}
