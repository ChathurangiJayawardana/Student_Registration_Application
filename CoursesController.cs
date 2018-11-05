using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StudentRegistrationApplication.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Courses
        public ViewResult Index()
        {
            var courses = _context.Courses.Include(m => m.Department).ToList();
            return View(courses);
        }
        public ActionResult Details(string id)
        {
            var course = _context.Courses.Include(m => m.Department).SingleOrDefault(m => m.Id == id);
            if (course == null)


                return HttpNotFound();

            return View(course);

        }


        }
    }