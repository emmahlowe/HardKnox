using HardKnock.DAL;
using HardKnock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardKnock.Controllers
{
    public class StudentController : Controller
    {
        private HardKnoxContext db = new HardKnoxContext();

        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student_Majors> student_majors = //we are creating a collection of student_major model objects or a collection of data 
                db.Database.SqlQuery<Student_Majors>("SELECT Student.Student_ID, Student.Student_FirstName, " +
                "Student.Student_LastName, Student.Student_EnrollmentDate, Student.Student_GPA, " +
                "Student.Major_ID, Majors.Major_Description " +
                "FROM Student INNER JOIN Majors ON Student.Major_ID = Majors.Major_ID " +
                "ORDER BY Student.Student_LastName, Student.Student_FirstName ");
            return View(student_majors); //sending this data to the index view
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                IEnumerable<Student_Majors> student_majors = //we are creating a collection of student_major model objects or a collection of data 
                db.Database.SqlQuery<Student_Majors>("SELECT Student.Student_ID, Student.Student_FirstName, " +
                "Student.Student_LastName, Student.Student_EnrollmentDate, Student.Student_GPA, " +
                "Student.Major_ID, Majors.Major_Description " +
                "FROM Student INNER JOIN Majors ON Student.Major_ID = Majors.Major_ID " +
                "WHERE Student.Student_ID = " + id);
                return View(student_majors.FirstOrDefault()); //we tell the system we are only working with one record by saying .FirstOrDefault. If we don't include this it will puke.
            }
            else
            {
                return RedirectToAction("Index", "Student");
            }
             
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                IEnumerable<Student> students = //we are creating a collection of student_major model objects or a collection of data 
                db.Database.SqlQuery<Student>("SELECT Student.Student_ID, Student.Student_FirstName, " +
                "Student.Student_LastName, Student.Student_EnrollmentDate, Student.Student_GPA, " +
                "Student.Major_ID " +
                "FROM Student " +
                "WHERE Student.Student_ID = " + id);
                return View(students.FirstOrDefault()); //we tell the system we are only working with one record by saying .FirstOrDefault. If we don't include this it will puke.
            }
            else
            {
                return RedirectToAction("Index", "Student");
            }
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Student_ID, Student_FirstName, Student_LastName, Student_EnrollmentDate, Major_ID")] Student students)
        {
           if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Student WHERE Student.Student_ID = " + id);
            }
            return RedirectToAction("Index", "Student");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Student_ID, Student_FirstName, Student_LastName, Student_EnrollmentDate, Student_GPA, Major_ID")] Student students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View();
            }
        }
    }
}