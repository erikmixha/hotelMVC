using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorPanel2018v3.Models.New_Clases
{
    public class RoomBook
    {
        public int? BookingID { get; set; }
        public int? Numberofpeople { get; set; }
        public DateTime? Arrival_date { get; set; }
        public DateTime? Departure_date { get; set; }
        public int? RoomID { get; set; }

        public string RoomStatus { get; set; }
        public Nullable<int> FacilityID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Floor { get; set; }


    }
}