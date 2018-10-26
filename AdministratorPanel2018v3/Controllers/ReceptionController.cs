using AdministratorPanel2018v3.Models;
using AdministratorPanel2018v3.Models.New_Clases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdministratorPanel2018v3.Controllers
{
    [Authorize(Roles = "Receptionist")]
    public class ReceptionController : Controller
    {
        HotelDatabase2018Entities1 db = new HotelDatabase2018Entities1();

        // GET: Reception
        public ActionResult Index()
        {
            ViewBag.Rooms = db.Rooms.ToList().Count();
            ViewBag.Clients = db.Clients.ToList().Count();
            ViewBag.Bookings = db.Bookings.ToList().Count();
            return View();
        }

        public PartialViewResult All()
        {
            List<Client> model = db.Clients.ToList();
            return PartialView("_Customer", model);
        }





        public PartialViewResult Bookings()
        {


            var bok = (from b in db.Bookings
                       join c in db.Booking_Rooms on b.BookingID equals c.BookingID
                       join r in db.Rooms on c.RoomID equals r.RoomID
                       select new RoomBook
                       {
                           BookingID = b.BookingID,
                           RoomID = r.RoomID,
                           Numberofpeople = b.Numberofpeople,
                           Arrival_date = b.Arrival_date,
                           Departure_date = b.Departure_date,
                           RoomStatus = r.RoomStatus,

                       }).ToList();


            return PartialView("_Booking_Room", bok);
        }

        public ActionResult Book()
        {           
                     
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book([Bind(Include = "BookingID,Numberofpeople,Arrival_date,Departure_date,RoomID")]  Booking bok)
        {

            if (ModelState.IsValid)
            {
                db.Bookings.Add(bok);
                db.SaveChanges();
                
            }

            return View("ClientInfo");
        }


        public ActionResult ClientInfo()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientInfo([Bind(Include = "ClientID,Firstname,Email")]  Client cli)
        {

            if (ModelState.IsValid)
            {
                db.Clients.Add(cli);
                db.SaveChanges();
            }

            return View("Index");
        }

        public ActionResult MarkStatus()
        {
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MarkStatus([Bind(Include = "RoomID,RoomStatus,RoomDescription,Size,Price,Floor,FacilityID")]  Room ro)
        {

            if (ModelState.IsValid)
            {
                db.Rooms.Add(ro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ro);
        }



        public ActionResult RoomStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            RoomFacility fac = db.RoomFacilities.Find(id);

            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID",room.RoomID);
            return View(room);

        }

        [HttpPost]

        public ActionResult RoomStatus(Room ro)
        {
            if (ModelState.IsValid)
            {


                db.Entry(ro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID", ro.RoomID);

            return View(ro);
        }



    }
}