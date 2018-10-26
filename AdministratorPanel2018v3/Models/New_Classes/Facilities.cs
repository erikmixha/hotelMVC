using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorPanel2018v3.Models.New_Clases
{
    public class Facilities
    {
        public int RoomID { get; set; }
        public string RoomStatus { get; set; }
        public Nullable<int> FacilityID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Floor { get; set; }
        public string RoomDescription { get; set; }
        public Nullable<bool> AirCon { get; set; }
        public Nullable<bool> Tv { get; set; }
        public Nullable<bool> Telephone { get; set; }
        public Nullable<bool> Balcony { get; set; }
        public Nullable<bool> Parking { get; set; }

    }
}