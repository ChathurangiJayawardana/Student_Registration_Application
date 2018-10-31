using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentReg.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ViewResult Index()
        {
            var students = GetStudents();
            return View(students);
        }
        public ActionResult Details(string id)
        {
            var student = GetStudents().SingleOrDefault(c => c.Id == id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }
        private IEnumerable<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student {Id="164001A", Name="Abeyrathne K.L.M."},
                  new Student {Id="164002B", Name="Bandara M.Y."},
                  new Student{Id="164003C",Name="De silva A.R."},
                    new Student{Id="164004D",Name="Ekanayake T.D."}
            };
        }
    }
}