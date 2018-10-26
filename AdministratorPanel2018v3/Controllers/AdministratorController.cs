using AdministratorPanel2018v3.Models;
using AdministratorPanel2018v3.Models.New_Clases;
using AdministratorPanel2018v3.Models.New_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdministratorPanel2018v3.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        // GET: Administrator

        HotelDatabase2018Entities1 db = new HotelDatabase2018Entities1();
        List<Employee_Account> acc = new List<Employee_Account>();
        List<Employee_Roles> e_r = new List<Employee_Roles>();

        public ActionResult Index()
        {
            ViewBag.number_of_clients = db.Clients.ToList().Count();
            ViewBag.Accounts = db.Accounts.ToList().Count();
            ViewBag.Bookings = db.Bookings.ToList().Count();

            return View();
        }


        public PartialViewResult All()
        {
            List<Client> model = db.Clients.ToList();
            return PartialView("_Customer", model);
        }


        public PartialViewResult ActiveEmp()
        {


            var employee = (from e in db.Employees
                            join a in db.Accounts
                            on e.AccountID equals a.AccountID

                            select new Employee_Account
                            {
                                EmployeeID = e.EmployeeID,
                                AccountID = a.AccountID,
                                Firstname = e.Firstname,
                                Lastname = e.Lastname,
                                Status = e.Status,
                                Email = a.Email
                            }).ToList();

            acc = employee;

            return PartialView("_Employee", employee);
        }


        public ActionResult SystemUsers()
        {  
            var emp = (from e in db.Employees
                       join r in db.Roles on e.RoleID equals r.RoleID
                       select new SystemUsers
                       {
                           Firstname = e.Firstname,
                           Lastname = e.Lastname,
                           RoleID = r.RoleID,
                           Description = r.Description

                       }).ToList();
            var cus = (from e in db.Clients
                       join r in db.Roles on e.RoleID equals r.RoleID
                       select new SystemUsers
                       {
                           Firstname = e.Firstname,
                           Lastname = e.Lastname,
                           RoleID = r.RoleID,
                           Description = r.Description
                       }).ToList();

            var alluser = emp.Union(cus).ToList();

            return View(alluser);
        }



        public ActionResult ChangeEmail(int? id)
        {
            var acc = from e in db.Employees
                      where e.EmployeeID == id
                      select e;

            var user = acc.ToList();

            ViewBag.one = user.ElementAt(0).EmployeeID;
            ViewBag.two = user.ElementAt(0).AccountID;
            int? a_id = user.ElementAt(0).AccountID;
            Session["accid"] = a_id;
            return View("ChangeEmailUserInput");
        }
        [HttpPost]
        public ActionResult ChangeEmailUserInput(string txtEmail)
        {

            if (ModelState.IsValid)
            {
                int actID = Convert.ToInt16(Session["accid"]);
                Account q = db.Accounts.Where(e => e.AccountID == actID).FirstOrDefault<Account>();
                q.Email = txtEmail;
                db.SaveChanges();
            }
            return View("Index");


        }



        public ActionResult Delete(int? id)
        {


            var del = db.Employees.Find(id);



            Account acc = db.Accounts.Find(del.AccountID);
            db.Employees.Remove(del);
            db.Accounts.Remove(acc);
            db.SaveChanges();



            return RedirectToAction("Index", "Administrator");





        }


        public PartialViewResult Roles()
        {


            var role = (from e in db.Employees
                        join r in db.Roles
                        on e.RoleID equals r.RoleID
                        select new Employee_Roles
                        {
                            EmployeeID = e.EmployeeID,
                            Firstname = e.Firstname,
                            Lastname = e.Lastname,
                            RoleID = r.RoleID,

                            Description = r.Description
                        }).ToList();




            e_r.AddRange(role);

            return PartialView("_Employee_Roles", role);
        }

        public ActionResult RoleEdit(int? id)
        {
            Employee q = db.Employees.Where(e => e.EmployeeID == id).FirstOrDefault<Employee>();
            return View(q);

        }

        [HttpPost]

        public ActionResult RoleEdit(Employee q)
        {
            if (ModelState.IsValid)
            {

                db.Entry(q).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(q);
        }


        public PartialViewResult Accounts()
        {


            var acco = (from e in db.Employees
                        join a in db.Accounts
                        on e.AccountID equals a.AccountID
                        select new Employee_Account
                        {
                            EmployeeID = e.EmployeeID,
                            AccountID = a.AccountID,
                            Firstname = e.Firstname,
                            Lastname = e.Lastname,
                            Status = e.Status
                        }).ToList();


            acc.AddRange(acc);
            return PartialView("_Employee_Account", acco);
        }

        public ActionResult StatusEdit(int? id)
        {
            Employee ac = db.Employees.Where(e => e.EmployeeID == id).FirstOrDefault<Employee>();
            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountID");

            return View(ac);

        }

        [HttpPost]

        public ActionResult StatusEdit(Employee ac)
        {
            if (ModelState.IsValid)
            {

                db.Entry(ac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ac);
        }

        public ActionResult Add()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = " EmployeeID,Firstname,Lastname,Salary,AccountID,RoleID,Status")] Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "AccountID", "AccountID", emp.AccountID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Description", emp.RoleID);
            return View(emp);
        }



    }
}



    