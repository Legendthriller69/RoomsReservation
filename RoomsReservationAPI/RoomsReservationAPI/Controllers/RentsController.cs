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
    public class RentsController : ApiController
    {
        private RoomsReservationAPIContext db = new RoomsReservationAPIContext();

        [HttpGet]
        [Route("api/Rents")]
        public IQueryable<Rent> GetRents()
        {
            return db.Rents.Include("Room.RoomType").Include("Client");
        }

        [HttpGet]
        [Route("api/Rents/{id}")]
        [Route("Rents/{id}")]
        public IHttpActionResult GetRent(int id)
        {
            var rent = db.Rents.Include("Room.RoomType").Include("Client").FirstOrDefault((c) => c.Id == id);
            if (rent == null)
            {
                return NotFound();
            }
            return Ok(rent);
        }

        [HttpPost]
        [Route("api/Rents")]
        public IHttpActionResult AddRent([FromBody] Rent r)
        {
            if (r == null)
                return NotFound();

            db.Rooms.Attach(r.Room);
            db.Clients.Attach(r.Client);
            db.Rents.Add(r);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("api/Rents")]
        public IHttpActionResult UpdateRent([FromBody] Rent r)
        {
            var rent = db.Rents.Include("Room.RoomType").Include("Client").FirstOrDefault((c) => c.Id == r.Id);

            if (rent == null)
                return NotFound();
            
            rent.Room = db.Rooms.FirstOrDefault(x => x.Id == r.Room.Id);
            rent.Client = db.Clients.FirstOrDefault(x => x.Id == r.Client.Id);
            rent.BeginDate = r.BeginDate;
            rent.EndDate = r.EndDate;

            db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("api/Rents/{id}")]
        public IHttpActionResult DeleteRent(int id)
        {
            var rent = db.Rents.Include("Room.RoomType").Include("Client").FirstOrDefault((c) => c.Id == id);
            if (rent != null)
            {
                db.Rents.Remove(rent);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}