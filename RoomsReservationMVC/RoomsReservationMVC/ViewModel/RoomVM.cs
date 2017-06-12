using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace RoomsReservationMVC.ViewModel
{
    public class RoomVM
    {
        public IEnumerable<Room> Rooms { get; set; }
    }
}