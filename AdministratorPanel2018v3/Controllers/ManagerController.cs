using AdministratorPanel2018v3.Models;
using AdministratorPanel2018v3.Models.New_Clases;
using AdministratorPanel2018v3.Models.RoomMethods;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace AdministratorPanel2018v3.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        HotelDatabase2018Entities1 db = new HotelDatabase2018Entities1();

        // GET: Manager
        public ActionResult Index()
        {
            ViewBag.Rooms = db.Rooms.ToList().Count();
            ViewBag.Clients = db.Clients.ToList().Count();
            ViewBag.Bookings = db.Bookings.ToList().Count();
            return View();
        }
        public PartialViewResult RoomList()
        {
            return PartialView(db.Rooms.ToList());
        }


        public ActionResult AddRoom()
        {
            return View();
        }
        public ActionResult SaveData(Room_Facilies_Photo r, FormCollection formCollection)
        {
            FacilitiesClassM facility = new FacilitiesClassM(formCollection["Aircon"], formCollection["Tv"], formCollection["Telephone"], formCollection["Balcony"], formCollection["Parking"]);
            facility.CheckIfExists();
            int facilityid = facility.GetFacilityID();


            RoomClassM room = new RoomClassM(formCollection["Status"], r.Price, facilityid, r.Floor,r.RoomDescription,r.Size);

            room.AddRoom();

           
           
          
            return View("Photo");
        }


        public ActionResult Photo()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Photo(Image img, HttpPostedFileBase doc)
        {

            if (ModelState.IsValid && doc != null)
            {
                var filename = Path.GetFileName(doc.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png")
                {
                    var path = HostingEnvironment.MapPath(Path.Combine("/Content/RoomPictures/", filename));
                    doc.SaveAs(path);
                    img.Img_Path = "/Content/RoomPictures/" + filename;
                    db.Images.Add(img);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(img);
                }

            }
            ModelState.AddModelError("", "Photo is required");
            
            return View(img);
        }

        public ActionResult EditRoom(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room ro = db.Rooms.Where(e => e.RoomID == id).FirstOrDefault<Room>();
            if (ro == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacilityID = new SelectList(db.RoomFacilities, "FacilityID", "FacilityID");

            return View(ro);

        }

        [HttpPost]

        public ActionResult EditRoom(Room ro)
        {
            if (ModelState.IsValid)
            {

                db.Entry(ro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ro);
        }

        public ActionResult EditFacilities(int? id)
        {
            
            RoomFacility fa = db.RoomFacilities.Where(e => e.FacilityID == id).FirstOrDefault<RoomFacility>();
            
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID");
            ViewBag.FacilityID = new SelectList(db.RoomFacilities, "FacilityID", "FacilityID");

            return View(fa);

        }

        [HttpPost]

        public ActionResult EditFacilities(RoomFacility fa)
        {
            if (ModelState.IsValid)
            {

                db.Entry(fa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fa);
        }
        

       
        public ActionResult Delete(int? id)
        {
            
            var del = db.Rooms.Find(id);



            RoomFacility fac = db.RoomFacilities.Find(del.FacilityID);

            db.Rooms.Remove(del);
            db.RoomFacilities.Remove(fac);

            db.SaveChanges();



            return RedirectToAction("Index");

            
        }


    }
}