using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DTO;

namespace RoomsReservationMVC.ViewModel
{
    public class ClientVM
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public Client Client { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}