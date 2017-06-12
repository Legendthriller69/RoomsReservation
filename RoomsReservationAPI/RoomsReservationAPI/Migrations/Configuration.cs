namespace RoomsReservationAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RoomsReservationAPI.Models.RoomsReservationAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoomsReservationAPI.Models.RoomsReservationAPIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.RoomTypes.AddOrUpdate(
                r => r.Id, 
                new RoomType { Id = 1, Name = "Chambre pour 2 adultes, lit double avec vue sur la mer", NbAdults = 2, NbChildren = 0, NbSimpleBeds = 0, NbDoubleBeds = 1, HasBalcon = false, ViewOnTheSea = true, Price = 80m },
                new RoomType { Id = 2, Name = "Chambre pour 1 adulte, lit simple avec balcon et vue sur la mer", NbAdults = 1, NbChildren = 0, NbSimpleBeds = 1, NbDoubleBeds = 0, HasBalcon = true, ViewOnTheSea = true, Price = 75m },
                new RoomType { Id = 3, Name = "Chambre pour 2 adultes et 1 enfant, 1 lit double et 1 lit simple, avec balcon et vue sur la mer", NbAdults = 2, NbChildren = 1, NbSimpleBeds = 1, NbDoubleBeds = 1, HasBalcon = true, ViewOnTheSea = true, Price = 120m }
            );

            context.Rooms.AddOrUpdate(
                r => r.Id,
                new Room { Id = 1, Number = 101, Busy = false, RoomType = context.RoomTypes.Find(1) },
                new Room { Id = 2, Number = 102, Busy = false, RoomType = context.RoomTypes.Find(1) },
                new Room { Id = 3, Number = 103, Busy = false, RoomType = context.RoomTypes.Find(1) },
                new Room { Id = 4, Number = 104, Busy = false, RoomType = context.RoomTypes.Find(1) },
                new Room { Id = 5, Number = 201, Busy = false, RoomType = context.RoomTypes.Find(2) },
                new Room { Id = 6, Number = 202, Busy = false, RoomType = context.RoomTypes.Find(2) },
                new Room { Id = 7, Number = 203, Busy = false, RoomType = context.RoomTypes.Find(2) },
                new Room { Id = 8, Number = 204, Busy = false, RoomType = context.RoomTypes.Find(2) },
                new Room { Id = 9, Number = 301, Busy = false, RoomType = context.RoomTypes.Find(3) },
                new Room { Id = 10, Number = 302, Busy = false, RoomType = context.RoomTypes.Find(3) },
                new Room { Id = 11, Number = 303, Busy = false, RoomType = context.RoomTypes.Find(3) },
                new Room { Id = 12, Number = 304, Busy = false, RoomType = context.RoomTypes.Find(3) }
            );

            context.Clients.AddOrUpdate(
                c => c.Id,
                new Client { Id = 1, Email = "pedro@pedro.com", Firstname = "Pedro", Name = "Ferreira" },
                new Client { Id = 2, Email = "kev@kev.com", Firstname = "Kevin", Name = "Carneiro" },
                new Client { Id = 3, Email = "test@test.com", Firstname = "Test", Name = "Test" }
            );

            context.Rents.AddOrUpdate(
                r => r.Id,
                new Rent { Id = 1, Client = context.Clients.Find(1), Room = context.Rooms.Find(1), BeginDate = Convert.ToDateTime("19.05.2017"), EndDate = Convert.ToDateTime("26.05.2017") },
                new Rent { Id = 2, Client = context.Clients.Find(2), Room = context.Rooms.Find(5), BeginDate = Convert.ToDateTime("08.06.2017"), EndDate = Convert.ToDateTime("17.06.2017") },
                new Rent { Id = 3, Client = context.Clients.Find(3), Room = context.Rooms.Find(9), BeginDate = Convert.ToDateTime("22.05.2017"), EndDate = Convert.ToDateTime("25.05.2017") }
                );
        }
    }
}
