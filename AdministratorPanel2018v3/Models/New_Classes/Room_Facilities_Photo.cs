using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdministratorPanel2018v3.Models.New_Clases
{
    public class Room_Facilies_Photo
    {
        public int RoomID { get; set; }
        public string RoomStatus { get; set; }
        [DataType(DataType.MultilineText)]

        public string RoomDescription { get; set; }
        public Nullable<int> Size { get; set; }
        public Nullable<int> FacilityID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<bool> AirCon { get; set; }
        public Nullable<bool> Tv { get; set; }
        public Nullable<bool> Telephone { get; set; }
        public Nullable<bool> Balcony { get; set; }
        public Nullable<bool> Parking { get; set; }
        public string ImgPath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}