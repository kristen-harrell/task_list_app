using DunderMifflin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DunderMifflin.Controllers
{
    public class DunderMifflinController : Controller
    {
        private readonly DunderMifflinContext _db;
        public DunderMifflinController(DunderMifflinContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult MyPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MyTaskList(string Email)
        {
            if(Email == "admin@dm.com")
            {
                List<ToDo> ListAll =_db.ToDo.ToList();
                return View(ListAll);
            }
            else
            {
            List<ToDo> filteredToDo = _db.ToDo.Where(ToDo => ToDo.Email == Email).ToList();
            return View(filteredToDo);
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDo t)
        {
            if (ModelState.IsValid)
            {
                _db.ToDo.Add(t);
                _db.SaveChanges();
            }
            return RedirectToAction("MyPage");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            ToDo t = _db.ToDo.Find(Id);
            return View(t);
        }
        [HttpPost]
        public IActionResult Update(ToDo t)
        {
            _db.ToDo.Update(t);
            _db.SaveChanges();
            return RedirectToAction("MyPage");
        }
      
        public IActionResult Delete(int Id)
        {
            ToDo t = _db.ToDo.Find(Id);
            return View(t);
        }

        [HttpPost]
        public IActionResult Delete(ToDo t)
        {
            _db.ToDo.Remove(t);
            _db.SaveChanges();
            return RedirectToAction("MyPage");
        }
    }
}
