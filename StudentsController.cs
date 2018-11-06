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
        public ActionResult Edit(string id)
        {
            var student = _context.Students.SingleOrDefault(c => c.Id == id);
            if (student == null)
                return HttpNotFound();
            var viewModel = new StudentFormViewModel
            {
                Student = student,
                AcademicTypes = _context.AcademicTypes.ToList()
            };
            return View("StudentForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (student.Id == null)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(c => c.Id == student.Id);

                studentInDb.Name = student.Name;
                studentInDb.RegisterDate = student.RegisterDate;
                studentInDb.IndexNo = student.IndexNo;
                studentInDb.RegisterDate = student.RegisterDate;
                studentInDb.AcademicType = student.AcademicType;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Students");
        }
        public ActionResult New()
        {
            var academicTypes = _context.AcademicTypes.ToList();
            var viewModel = new StudentFormViewModel
            {
                AcademicTypes = academicTypes
            };
            return View("StudentForm",viewModel);
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