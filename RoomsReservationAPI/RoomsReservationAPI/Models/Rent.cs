using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomsReservationAPI.Models
{
    public class Rent
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Room Room { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}