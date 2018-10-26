using AdministratorPanel2018v3.Models;
using AdministratorPanel2018v3.Models.New_Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdministratorPanel2018v3.Controllers
{
    public class ClientController : Controller
    {
        HotelDatabase2018Entities1 db = new HotelDatabase2018Entities1();
        List<RoomDescription> list = new List<RoomDescription>();
        List<Client> cl = new List<Client>();
        int value;

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Feedback()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Feedback(FormCollection frm)
        {

            if (ModelState.IsValid)
            {

                string email = frm["email"].ToString();

                var q = (from c in db.Clients
                         where c.Email == email
                         select c).ToList();
                if (q.Count() != 0)
                {

                    db.FeedBacks.Add(new FeedBack()
                    {
                        Description = frm["description"].ToString(),
                        ClientID = q.ElementAt(0).ClientID




                    });



                    db.SaveChanges();
                }


            }

            return View("Index");
        }



        public ActionResult Login()
        {
            return View();
        }

       


        public ActionResult Checkin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkin(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {


                Session["Number"] = formCollection["Number"];
                Session["Firstname"] = formCollection["Firstname"];
                Session["LastName"] = formCollection["LastName"];
                Session["Email"] = formCollection["Email"];
                Session["ArrivalDate"]= formCollection["ArrivalDate"];

                Session["Number of dates"] = formCollection["Number of dates"];
                Session["CID"] = "o";
                string email = Session["Email"].ToString();
                var cus = from c in db.Clients
                          where c.Email == email
                          select c;
                cl = cus.ToList<Client>(); 
                value = cus.ToList().Count();
                if (value == 0)
                {
                    Session["info"] = 0;
                    db.Clients.Add(new Client()
                    {
                        Firstname = Session["Firstname"].ToString(),
                        Lastname = Session["LastName"].ToString(),
                        Email = email

                    });
                    db.SaveChanges();
                    var cus1 = from c in db.Clients
                               select c;

                    int cid = Convert.ToInt32(cus1.ToList().Count());
                    Session["CID"] = cid;

                    return RedirectToAction("AvList");


                }
                else
                {
                    Session["info"] = 1;
                    Session["CID"] = cl.ElementAt(0).ClientID;


                    return RedirectToAction("AvList");

                }




            }
            return View("AvList");
        }


        public ActionResult AvList()
        {
            DateTime start, end;
            int numberofd = Convert.ToInt32(Session["Number of dates"]);
            int nr = Convert.ToInt32(Session["Number"]);
            string date = Session["ArrivalDate"].ToString();
            start = DateTime.Parse(date);
            end = start.AddDays(nr);

            var roomlist = (from Room in db.Rooms
                            join br in db.Booking_Rooms on Room.RoomID equals br.RoomID
                            join b in db.Bookings on br.BookingID equals b.BookingID
                            join rf in db.RoomFacilities on Room.FacilityID equals rf.FacilityID

                            where (DateTime.Compare(start, (DateTime)b.Departure_date) <= 0) 
                            where Room.Size >= nr

                            select new RoomDescription
                            {
                                RoomID = Room.RoomID,

                                RoomStatus = Room.RoomStatus,
                                Price = Room.Price,
                                Floor = Room.Floor,
                                AirCon = rf.AirCon,
                                Tv = rf.Tv,
                                Telephone = rf.Telephone,
                                Balcony = rf.Balcony,
                                Parking = rf.Parking,
                                Size = Room.Size,
                                Days = numberofd,
                                Total = (numberofd * Room.Price)

                            }).ToList();

            int cid = Convert.ToInt32(Session["CID"]);
            var room = (from r in db.Rooms
                        join rf in db.RoomFacilities
                        on r.FacilityID equals rf.FacilityID
                        where r.Size >= nr

                        select new RoomDescription
                        {
                            RoomID = r.RoomID,

                            RoomStatus = r.RoomStatus,
                            Price = r.Price,
                            Floor = r.Floor,
                            AirCon = rf.AirCon,
                            Tv = rf.Tv,
                            Telephone = rf.Telephone,
                            Balcony = rf.Balcony,
                            Parking = rf.Parking,
                            Size = r.Size,
                            Days = numberofd,
                            Total = (numberofd * r.Price)

                        }).ToList();
            var remains = room.Where(p => !roomlist.Any(p2 => p2.RoomID == p.RoomID));
            int value = remains.Count();
            if (value >= 1)
            {
                ViewBag.Av = 1;
            }
            else
            {
                ViewBag.Av = 0;
            }
            return View(remains.ToList());


        }

        public ActionResult Book(int id)
        {

            if (id != 0)
            {
                int numdays = Convert.ToInt32(Session["Number of dates"]);

                var room = (from r in db.Rooms
                            join rf in db.RoomFacilities
                            on r.FacilityID equals rf.FacilityID

                            where r.RoomID == id
                            
                            select new RoomDescription
                            {
                                RoomID = r.RoomID,

                                RoomStatus = r.RoomStatus,
                                Price = r.Price,
                                Floor = r.Floor,
                                AirCon = rf.AirCon,
                                Tv = rf.Tv,
                                Telephone = rf.Telephone,
                                Balcony = rf.Balcony,
                                Parking = rf.Parking,
                                Size = r.Size,
                                Days = numdays,
                                Total = (numdays * r.Price)
                            }).ToList();

                if (Session["cart"] == null)
                {

                    list = room.ToList<RoomDescription>();

                    Session["cart"] = list;
                    ViewBag.cart = list.Count();

                    Session["count"] = 1;


                }
                else
                {

                    list = (List<RoomDescription>)Session["cart"];


                    foreach (var userData in room.ToList())
                    {
                        list.Add(new RoomDescription()
                        {
                            RoomID = userData.RoomID,

                            RoomStatus = userData.RoomStatus,
                            Price = userData.Price,
                            Floor = userData.Floor,
                            AirCon = userData.AirCon,
                            Tv = userData.Tv,
                            Telephone = userData.Telephone,
                            Balcony = userData.Balcony,
                            Parking = userData.Parking,
                            Size = userData.Size,
                            Days = numdays,
                            Total = (numdays * userData.Price)

                        });


                    }

                    Session["cart"] = list;
                    ViewBag.cart = list.Count();
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }




            }
            return RedirectToAction("AvList");
        }

        public ActionResult Myorder()
        {

            return View((List<RoomDescription>)Session["cart"]);

        }
        public ActionResult Remove(int id)
        {
            list = (List<RoomDescription>)Session["cart"];
            if (list.Count() > 1) { 
            list.RemoveAll(x => x.RoomID == id);
            }
            Session["cart"] = list;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder");

        }

        public ActionResult Save()
        {
            list = (List<RoomDescription>)Session["cart"];
            int nr = Convert.ToInt32(Session["Number of dates"]);
            int cid = Convert.ToInt32(Session["CID"]);
            DateTime start, end;           
            string date = Session["ArrivalDate"].ToString();
            start = DateTime.Parse(date);
            end = start.AddDays(nr);

            foreach (var el in list)
            {
                Room r = db.Rooms.Single(x => x.RoomID == el.RoomID);
                r.RoomStatus = "Occupied";
                db.SaveChanges();
                db.Bookings.Add(new Booking()
                {
                    Numberofpeople = el.Size,
                    Arrival_date = start,
                    Departure_date = end,
                    ClientID = cid
                });
                db.SaveChanges();
                var cus1 = from c in db.Bookings
                           select c;
               
                int boknr = Convert.ToInt32(cus1.ToList().Count());
                db.Booking_Rooms.Add(new Booking_Rooms()
                {
                    RoomID = el.RoomID,
                    BookingID = boknr
                });
                db.SaveChanges();
                 Session.Clear();

            }

            return View();

        }


    }
        
}