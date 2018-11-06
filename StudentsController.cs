﻿using StudentRegistrationApplication.Models;
using StudentRegistrationApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentReg.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
              _context.Dispose();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
        public ActionResult New()
        {
            var academicTypes = _context.AcademicTypes.ToList();
            var viewModel = new NewStudentViewModel
            {
                AcademicTypes = academicTypes
            };
            return View(viewModel);
        }
        // GET: Students
        public ViewResult Index()
        {
            var students = _context.Students.Include(c =>c.AcademicType).ToList();
            return View(students);
        }
        public ActionResult Details(string id)
        {
            var student = _context.Students.Include(c => c.AcademicType).SingleOrDefault(c => c.Id == id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }


       
    }
}