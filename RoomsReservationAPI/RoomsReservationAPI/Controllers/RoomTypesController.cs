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
    public class RoomTypesController : ApiController
    {
        private RoomsReservationAPIContext db = new RoomsReservationAPIContext();

        public IQueryable<RoomType> GetRoomTypes()
        {
            return db.RoomTypes;
        }

        [HttpGet]
        [Route("api/RoomTypes/{id}")]
        [Route("RoomTypes/{id}")]
        public IHttpActionResult GetRoomType(int id)
        {
            var roomType = db.RoomTypes.FirstOrDefault((r) => r.Id == id);
            if (roomType == null)
            {
                return NotFound();
            }
            return Ok(roomType);
        }
    }
}