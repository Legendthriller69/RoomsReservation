using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomsReservationMVC.ViewModel;
using BLL;

namespace RoomsReservationMVC.Controllers
{
    public class RoomsController : Controller
    {
        public ActionResult Index()
        {
            RoomAPI roomAPI = new RoomAPI();
            RoomVM vm = new RoomVM
            {
                Rooms = roomAPI.GetRooms()
            };

            return View(vm);
        }
    }
}