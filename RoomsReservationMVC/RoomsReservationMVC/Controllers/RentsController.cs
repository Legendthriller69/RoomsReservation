using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomsReservationMVC.ViewModel;
using BLL;

namespace RoomsReservationMVC.Controllers
{
    public class RentsController : Controller
    {
        public ActionResult Index()
        {
            RentAPI rentAPI = new RentAPI();
            RentVM vm = new RentVM
            {
                Rents = rentAPI.GetRents()
            };

            return View(vm);
        }

        public ActionResult Details(int id)
        {
            RentAPI rentAPI = new RentAPI();
            RentVM vm = new RentVM
            {
                Rent = rentAPI.GetRent(id)
            };
            return View(vm);
        }

        public ActionResult Add()
        {
            ClientAPI clientAPI = new ClientAPI();
            RoomTypeAPI roomTypeAPI = new RoomTypeAPI();
            RentVM vm = new RentVM();
            vm.Clients = clientAPI.GetClients();
            vm.RoomTypes = roomTypeAPI.GetRoomTypes();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(RentVM vm)
        {
            if (vm.BeginDate == null)
            {
                ModelState.AddModelError(string.Empty, "Veuillez remplir tous les champs");
                return View();
            }

            ClientAPI clientAPI = new ClientAPI();
            RentAPI rentAPI = new RentAPI();
            RoomAPI roomAPI = new RoomAPI();

            vm.Rent = new DTO.Rent();
            vm.Rent.BeginDate = vm.BeginDate;
            if(vm.EndDate != null)
                vm.Rent.EndDate = vm.EndDate;
            vm.Rent.Client = clientAPI.GetClient(vm.IdClient);
            vm.Rent.Room = roomAPI.GetRoomsByType(vm.IdRoomType).FirstOrDefault();
            vm.Rent.Room.Busy = true;
            roomAPI.EditRoom(vm.Rent.Room);

            //Ajout de la réservation
            rentAPI.AddRent(vm.Rent);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            RentAPI rentAPI = new RentAPI();
            ClientAPI clientAPI = new ClientAPI();
            RoomTypeAPI roomTypeAPI = new RoomTypeAPI();
            RentVM vm = new RentVM();
            vm.Rent = rentAPI.GetRent(id);
            vm.Clients = clientAPI.GetClients();
            vm.RoomTypes = roomTypeAPI.GetRoomTypes();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(RentVM vm)
        {
            if (vm.BeginDate == null)
            {
                ModelState.AddModelError(string.Empty, "Veuillez remplir le champ concernant la date de début");
                return View();
            }

            ClientAPI clientAPI = new ClientAPI();
            RentAPI rentAPI = new RentAPI();
            RoomAPI roomAPI = new RoomAPI();

            DTO.Rent rent = new DTO.Rent();
            rent.Id = vm.Rent.Id;
            rent.BeginDate = vm.BeginDate;
            if (vm.EndDate != null)
                rent.EndDate = vm.EndDate;
            rent.Client = clientAPI.GetClient(vm.IdClient);
            rent.Room = roomAPI.GetRoomsByType(vm.IdRoomType).FirstOrDefault();
            rentAPI.EditRent(rent);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            RentAPI rentAPI = new RentAPI();
            rentAPI.DeleteRent(id);

            return RedirectToAction("Index");
        }
    }
}