using Dot_Net_Core_application_16022024.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dot_Net_Core_application_16022024.Controllers
{
    public class Student : Controller
    {
        public readonly DatabaseContext _db;
        public Student(DatabaseContext context)
        {   
            _db = context;
        }

        [HttpGet]
        public IActionResult add( int id =0)
        {
           var data= _db.RR_tables.ToList();
            RR_table rR_Table = new RR_table();
            ViewBag.btn = "Save";

            if(id>0)
            {
                rR_Table.rid = data[0].rid;
                rR_Table.Username = data[0].Username;
                rR_Table.Email = data[0].Email;
                rR_Table.password = data[0].password;
                rR_Table.Status= data[0].Status;
                ViewBag.btn = "Change";
            }

            return View(rR_Table);
        }

        [HttpPost]
        public IActionResult add(RR_table rt)
        {
            if(ModelState.IsValid)
            {
                if (rt.rid > 0)
                {
                    _db.Entry(rt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else
                {
                    _db.RR_tables.Add(rt);
                }
            }
            else
            {
                return View();
            }
            
            _db.SaveChanges();
            return RedirectToAction("Show");
        }

        public IActionResult Show() 
        {
            var data= _db.RR_tables.ToList();
            return View(data);
        }

        public IActionResult Delete( int id) 
        {
            var data = _db.RR_tables.Find(id);
            _db.RR_tables.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Show");
        }

        public IActionResult Login(RR_table rl)
        {
          
            var data=(from a in _db.RR_tables where a.Email==rl.Email && a.password==rl.password select a).ToList();
            if(data.Count>0)
            {
                return RedirectToAction("Show", "Student");
            }
            else
            {
                return View();
            }

           
        }
    }
}
