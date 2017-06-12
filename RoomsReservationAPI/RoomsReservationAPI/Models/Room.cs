using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomsReservationAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public bool Busy { get; set; } 
        public RoomType RoomType { get; set; }
    }
}