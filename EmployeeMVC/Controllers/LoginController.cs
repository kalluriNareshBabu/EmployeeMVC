using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using EmployeeMVC.Models;
using EmployeeMVC.DataAccessLayer;

namespace EmployeeMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModels dm)
        {
            if (ModelState.IsValid)
            {
                int res;
                string msg;
                DBdata.login_check(dm, out msg, out res);

                ViewBag.Message = msg;

                //ViewData["result"] = res;
                //if (res == 1)
                //{
                    
                //    ViewData["msg"] = msg; 
                //}
                //else
                //{
                //    ModelState.AddModelError("", msg);
                //}
            }
            else
            {
                ModelState.AddModelError("", "OOPS!! Error in logging in. Please Enter valid details");
            }
            return View();
        }
    }
}