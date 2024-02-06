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
        public ActionResult Create( int ? id)
        {
            
            try
            {
                if (id.HasValue)
                {
                    var Get = _add.GetByID(id.Value);
                    return View("Create", Get);
                }
                else
                {
                    var result = new StudentDetails();
                    result.DOB = DateTime.Now;
                    result.Age = 0;
                    return View("Create", result);
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: StudentController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(StudentDetails value)
        {
            try
            {
                if(value.StudentID==0)
                {
                    _add.InsertStudent(value);
                   
                }
                else
                {
                    _add.UpdateStudent(value.StudentID, value);
                }
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
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteByID(int id)
        {
            try
            {
                _add.DeleteStudent(id);
                var result = _add.GetAllRecords();
                return View("View", result);

            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        [Route("~/api/depart")]
        public ActionResult Subject()
        {
            try
            {
                var get = Getvalue();
                return Ok(get.ToList());
            }
            catch(Exception )
            {
                throw;
            }
            finally
            {

            }

        }
        
            private List<Subject> Getvalue()
            {

                List<Subject> depart = new List<Subject>();
                Subject input = new Subject();
                input.ID = 1;
                input.Name = "ECE";
                depart.Add(input);

                Subject inner = new Subject();
                inner.ID = 2;
                inner.Name = "CSE";
                depart.Add(inner);

                Subject inter = new Subject();
                inter.ID = 3;
                inter.Name = "MECH";
                depart.Add(inter);
                return depart;

            }
        
    }
}

