using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdministratorPanel2018v3.Models.New_Clases
{
    public class BookARoom
    {
        [Key]
        public int BookingID { get; set; }
        [Key]
        public int RoomID { get; set; }

        public virtual Booking book { get; set; }
        public virtual Room room { get; set; }
    }
}