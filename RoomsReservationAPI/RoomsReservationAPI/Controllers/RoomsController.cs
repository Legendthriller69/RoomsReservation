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
    public class RoomsController : ApiController
    {
        private RoomsReservationAPIContext db = new RoomsReservationAPIContext();

        [HttpGet]
        [Route("api/Rooms")]
        public IQueryable<Room> GetRooms()
        {
            return db.Rooms.Include("RoomType");
        }

        [HttpGet]
        [Route("api/Rooms/{id}")]
        [Route("Rooms/{id}")]
        public IHttpActionResult GetRoom(int id)
        {
            var room = db.Rooms.Include("RoomType").FirstOrDefault((r) => r.Id == id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpGet]
        [Route("api/Rooms/ByType/{id}")]
        [Route("Rooms/ByType/{id}")]
        public IHttpActionResult GetRoomsByType(int id)
        {
            var room = from r in db.Rooms.Include("RoomType") where (r.RoomType.Id == id && r.Busy == false) select r;
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPut]
        [Route("api/Rooms")]
        public IHttpActionResult UpdateRoom([FromBody] Room r)
        {
            var room = db.Rooms.Include("RoomType").Single(x => x.Id == r.Id);

            if (room == null)
                return NotFound();

            room.Number = r.Number;
            room.Busy = r.Busy;

            db.SaveChanges();
            return Ok();
        }
    }
}