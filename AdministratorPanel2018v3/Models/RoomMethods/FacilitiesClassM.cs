using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministratorPanel2018v3.Models.RoomMethods
{
    public class FacilitiesClassM
    {
        HotelDatabase2018Entities1 db = new HotelDatabase2018Entities1();
        private string aircon;
        private string tv;
        private string tel;
        private string bal;
        private string park;
        private int id;

        

        public FacilitiesClassM(string aircon, string tv, string tel, string bal, string park)
        {
            this.aircon = aircon;
            this.tv = tv;
            this.tel = tel;
            this.bal = bal;
            this.park = park;
        }
        public int CheckIfExists()
        {
            bool b1 = aircon.Equals("1") ? true : false;
            bool b2 = tv.Equals("1") ? true : false;
            bool b3 = tel.Equals("1") ? true : false;
            bool b4 = bal.Equals("1") ? true : false;
            bool b5 = park.Equals("1") ? true : false;
            var check = (from f in db.RoomFacilities
                         where f.AirCon == b1
                         where f.Tv == b2
                         where f.Telephone == b3
                         where f.Balcony == b4
                         where f.Parking == b5
                         select f).ToList();
            if (check.Count() == 1)
            {
                 id = check.ElementAt(0).FacilityID;
                GetFacilityID( );
                return 1;
            }
            else
                
                AddFacility(b1,b2,b3,b4,b5);
                GetFacilityID();
                return 0;

        }

        private void AddFacility(bool b1, bool b2, bool b3, bool b4, bool b5)
        {
            db.RoomFacilities.Add(new RoomFacility()
            {
                AirCon = b1,

                Tv = b2,
                Telephone = b3,
                Balcony = b4,
                Parking=b5,

            });
            db.SaveChanges();
        }

        public int  GetFacilityID(){
            if (id==0) {
                var f = (from r in db.RoomFacilities
                         select r).ToList().Count();
                return f;
            } else {

                return id;
            }
            
            
        }

    }
}