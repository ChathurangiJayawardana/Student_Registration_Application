using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationApplication.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ViewResult Index()
        {
            var courses = GetCourses();
            return View(courses);
        }
        private IEnumerable<Course> GetCourses()
        {
            return new List<Course>
            {
                new Course{ Id="CM1100",Name="Mathematics and Statistics"},
                 new Course{ Id="IN1400",Name="Database Management System"},
                 new Course{Id="Is1200",Name="Principals of Management"}
            };
        }
    }
}