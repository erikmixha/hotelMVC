using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorPanel2018v3.Models.RoomMethods
{
    public class RoomClassM
    {
        HotelDatabase2018Entities1 db = new HotelDatabase2018Entities1();
        private int? facilityID;
        private int? floor;
        private decimal? price;
        private string status;
        private string roomdescription;
        private int? size;

        private string v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;
        private string v6;

        public RoomClassM(string status, decimal? price, int? facilityID, int? floor,string roomdescription,int? size)
        {
            this.status = status;
            this.price = price;
            this.facilityID = facilityID;
            this.floor = floor;
            this.roomdescription = roomdescription;
            this.size = size;
        }

        public RoomClassM(string v1, string v2, string v3, string v4,string v5,string v6)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;

        }

        public void AddRoom()
        {
            db.Rooms.Add(new Room()
            {
                RoomStatus = status,

                Price = price,
                FacilityID = facilityID,
                Floor = floor,
                RoomDescription = roomdescription,
                Size = size,
                

            });
            db.SaveChanges();
           


        }

        public int RoomID()
        {
            var rid = (from r in db.Rooms
                       select r).ToList();

            int number=rid.Count();

            return number;
        }

    }
}