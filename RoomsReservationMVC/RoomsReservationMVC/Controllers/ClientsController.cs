using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoomsReservationMVC.ViewModel;
using BLL;

namespace RoomsReservationMVC.Controllers
{
    public class ClientsController : Controller
    {
        public ActionResult Index()
        {
            ClientAPI clientAPI = new ClientAPI();
            ClientVM vm = new ClientVM
            {
                Clients = clientAPI.GetClients()
            };

            return View(vm);
        }

        public ActionResult Details(int id)
        {
            ClientAPI clientAPI = new ClientAPI();
            ClientVM vm = new ClientVM
            {
                Client = clientAPI.GetClient(id)
            };
            return View(vm);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ClientVM vm)
        {
            if (vm.Name == null || vm.Firstname == null || vm.Email == null)
            {
                ModelState.AddModelError(string.Empty, "Veuillez remplir tous les champs");
                return View();
            }

            vm.Client = new DTO.Client();
            vm.Client.Email = vm.Email;
            vm.Client.Name = vm.Name;
            vm.Client.Firstname = vm.Firstname;
            ClientAPI clientAPI = new ClientAPI();
            clientAPI.AddClient(vm.Client);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ClientAPI clientAPI = new ClientAPI();
            ClientVM vm = new ClientVM();
            vm.Client = clientAPI.GetClient(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Edit(ClientVM vm)
        {
            if (vm.Name == null || vm.Firstname == null || vm.Email == null)
            {
                ModelState.AddModelError(string.Empty, "Veuillez remplir tous les champs");
                return View();
            }

            DTO.Client client = new DTO.Client();
            client.Id = vm.Client.Id;
            client.Email = vm.Email;
            client.Name = vm.Name;
            client.Firstname = vm.Firstname;
            ClientAPI clientAPI = new ClientAPI();
            clientAPI.EditClient(client);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            RentAPI rentAPI = new RentAPI();
            var rents = rentAPI.GetRents();
            foreach(var rent in rents)
            {
                if (rent.Client.Id == id)
                    rentAPI.DeleteRent(rent.Id);
            }

            ClientAPI clientAPI = new ClientAPI();
            clientAPI.DeleteClient(id);

            return RedirectToAction("Index");
        }
    }
}