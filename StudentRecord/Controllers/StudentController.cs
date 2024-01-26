using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecord.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _add;
        private readonly string _connectionstring;
        public StudentController(IStudentRepository add, IConfiguration configuration)
        {
            _add = add;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var result = _add.GetAllRecords();
            return View("View",result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = _add.GetByID(id);
                return View("Details", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            try
            {
                var result = new StudentDetails();
                return View("Create", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDetails value)
        {
            try
            {
                _add.InsertStudent(value);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var result = _add.GetByID(id);
                return View("Edit", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StudentDetails value)
        {
            try
            {
                _add.UpdateStudent(id, value);
                var result = _add.GetAllRecords();
                return View("View", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _add.GetByID(id);
                return View("Delete", result);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteByID(int StudentID)
        {
            try
            {
                _add.DeleteStudent(StudentID);
                var result = _add.GetAllRecords();
                return View("View", result);
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        [Route("~/api/Subject")]
        public ActionResult Subject()
        {
            try
            {
                Dropdown Dvalue = new Dropdown();
                var get = Dvalue.Getvalue();
                return Ok(get.ToList());
            }

        }
    }
}
/*
 [http]
 
 
 
 
 */
