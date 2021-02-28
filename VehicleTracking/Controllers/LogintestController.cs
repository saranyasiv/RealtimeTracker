using MOdals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleTracking.Controllers
{
    public class LogintestController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Index(Login cred,string rtnurl)
        {
            if(cred.Username == "test" && cred.Password == "test")
            {
                //Session["UserID"] = obj.UserId.ToString();
                //Session["UserName"] = obj.UserName.ToString();
                //return RedirectToAction("UserDashBoard");
                return Redirect(rtnurl);
            }
            return View();
        }
    }
}