using StudentRegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationApplication.ViewModels
{
    public class RandomCourseViewModel
    {
        public Course Course { get; set; }
        public List<Student> Students { get; set; }
    }
}