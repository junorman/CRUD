using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        SchoolEntities _context = new SchoolEntities();
        public ActionResult Index()
        {
            var listOfdate = _context.Student.ToList();
            return View(listOfdate);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student model)
        {
            _context.Student.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data insert successfull!";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Student.Where(c => c.StudentId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Student Model)
        {   
            var data = _context.Student.Where(c => c.StudentId == Model.StudentId).FirstOrDefault();
            if(data != null)
            {
                data.StudentId = Model.StudentId;
                data.StudentName = Model.StudentName;
                data.StudentFees = Model.StudentFees;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            var data = _context.Student.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Student.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Student.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Successfully!";
            return RedirectToAction("Index");
        }
    }
}