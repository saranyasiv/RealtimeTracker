using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MOdals;
using Newtonsoft.Json;
using VehicleRepository;

namespace VehicleTracking.Controllers
{
    public class LoginController : Controller
    {
        private VehicleDbContext db = new VehicleDbContext();
        // GET: Login
        public JsonResult Mapview([Bind(Include = "username,password")] Login usr)
        {

            double lt = 8d;
            double ln = 8d;
            Locationinfo ltn = new Locationinfo();
            try
            {

                List<Locationinfo> lst = new List<Locationinfo>();
                using (VehicleDbContext dbc = new VehicleDbContext())
                {
                    lst = dbc.location.OrderBy(a => a.locationID ).ToList();
                }
                //var get_user = db.Login.FirstOrDefault(p => true);
                //usr.ID = get_user.ID;
                lt = lst[lst.Count - 1].lat;
                ln = lst[lst.Count - 1].lon;
            }
            catch (Exception ex)
            {
               
            }
           
            return Json(new { lat = lt, lon = ln },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Viewmap()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login([Bind(Include = "Username,Password")] Login login)
        {
            if (login.Username != null || login.Password != null)
            {
                var get_user = db.Login.FirstOrDefault(p => p.Username == login.Username
                && p.Password == login.Password);
                if (get_user != null)
                {
                    Session["UserName"] = get_user.Username.ToString();
                    return RedirectToAction("Viewmap");
                }
                else if (login.Username == null && login.Password != null)
                {
                    ModelState.AddModelError("", "Please enter Username");
                }
                else if (login.Password == null && login.Username != null)
                {
                    ModelState.AddModelError("", "Please enter Password");
                }
                else
                {
                    ModelState.AddModelError("", "No such user found.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please enter username and Password.");
            }

            return View();
        }
      
        [HttpPost]
        public ActionResult AddVal([Bind(Include = "lat,lon")] Locationinfo location)
        {
            if (ModelState.IsValid)
            {
                var _username = Session["UserName"];
                var get_user = db.Login.FirstOrDefault(p => p.Username == _username.ToString());
                location.ID = get_user.ID;
                db.location.Add(location);
                db.SaveChanges();
                return View(location);
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
