using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using System.ComponentModel.DataAnnotations;

namespace RoomsReservationMVC.ViewModel
{
    public class RentVM
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public Room Room { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Rent Rent { get; set; }
        public IEnumerable<Rent> Rents { get; set; }
        public IEnumerable<RoomType> RoomTypes { get; set; }
        public int IdClient { get; set; }
        public int IdRoomType { get; set; }
        public int IdRoom { get; set; }
    }
}