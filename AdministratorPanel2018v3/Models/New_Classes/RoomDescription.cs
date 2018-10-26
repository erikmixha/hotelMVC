using System;

namespace AdministratorPanel2018v3.Models.New_Clases
{
    public class RoomDescription
    {
        public int RoomID { get; set; }
        public string RoomStatus { get; set; }

        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Floor { get; set; }

        public Nullable<bool> AirCon { get; set; }
        public Nullable<bool> Tv { get; set; }
        public Nullable<bool> Telephone { get; set; }
        public Nullable<bool> Balcony { get; set; }
        public Nullable<bool> Parking { get; set; }


        public Nullable<int> Size { get; set; }

        public int Days { get; set; }
        public Nullable<decimal> Total { get; set; }





    }
}