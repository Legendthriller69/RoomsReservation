﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomsReservationAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
    }
}