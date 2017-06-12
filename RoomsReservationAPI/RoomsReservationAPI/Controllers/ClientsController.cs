using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RoomsReservationAPI.Models;

namespace RoomsReservationAPI.Controllers
{
    public class ClientsController : ApiController
    {
        private RoomsReservationAPIContext db = new RoomsReservationAPIContext();

        [HttpGet]
        [Route("api/Clients")]
        public IEnumerable<Client> GetClients()
        {
            return db.Clients;
        }

        [HttpGet]
        [Route("api/Clients/{id}")]
        [Route("Clients/{id}")]
        public IHttpActionResult GetClient(int id)
        {
            var client = db.Clients.FirstOrDefault((c) => c.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        [Route("api/Clients")]
        public IHttpActionResult AddClient([FromBody] Client c)
        {
            if (c == null)
                return NotFound();

            db.Clients.Add(c);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("api/Clients")]
        public IHttpActionResult UpdateClient([FromBody] Client c)
        {
            var client = db.Clients.Single(x => x.Id == c.Id);

            if (client == null)
                return NotFound();

            client.Email = c.Email;
            client.Name = c.Name;
            client.Firstname = c.Firstname;

            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("api/Clients/{id}")]
        public IHttpActionResult DeleteClient(int id)
        {
            var client = db.Clients.Single(x => x.Id == id);
            if (client != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}