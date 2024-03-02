using Dot_Net_Core_application_16022024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dot_Net_Core_application_16022024.Controllers
{
    public class Login_user : Controller
    {
        public readonly DatabaseContext _db;
      

        public Login_user(DatabaseContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Add_Login()
        {
            ViewData["ShowModal"] = true;
            return View();
        }

        [HttpPost]
        public IActionResult Add_Login(RRtbale1 rt)
        {
            if (ModelState.IsValid)
            {
                var data = (from a in _db.RR_tables where a.Email == rt.Email && a.password == rt.password && a.Status == 1 select a).ToList();
                if (data.Count > 0)
                {
                    HttpContext.Session.SetInt32("IDD", data[0].rid);
                    return RedirectToAction("Show_login", "Login_user");
                }
                else
                {
                    ViewBag.msg = "Login Faild Please Check Your Account Status !!";
                    return View();
                }
            }
            else
            {
                return View();
            }     
        }
        public IActionResult Show_login()
        {
            var id= HttpContext.Session.GetInt32("IDD");
            var data =(from a in _db.RR_tables where a.rid == id select a).ToList();
            return View(data);
        }
    }
}
