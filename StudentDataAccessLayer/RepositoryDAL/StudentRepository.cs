using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContxt _contxt;
        public StudentRepository(DbContxt contxt)
        {
            _contxt = contxt;
        }

        

       

        public void Insert(StudentDetails stud)
        {
            try
            {
                _contxt.Database.ExecuteSqlRaw($"exec InsertStudents '{stud.Name}','{stud.DOB}',{stud.Age},'{stud.Gender}',{stud.Mobile} ,'{stud.Email}','{stud.Subject}'");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Update(int id, StudentDetails stud)
        {
            try
            {
                var result = _contxt.Database.ExecuteSqlRaw($" UpdateStudents set Name='{stud.Name}',DOB='{stud.DOB}',Age={stud.Age},Gender='{stud.Gender}',MobileNum='{stud.Mobile}', Emailid='{stud.Email}',Subject='{stud.Subject}' where StudentID={id} ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(int studid)
        {
            try
            {
                _contxt.Database.ExecuteSqlRaw($"delete Students where StudentID={studid}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<StudentDetails> GetAllRecords()
        {
            try
            {
                var result = _contxt.Students.FromSqlRaw("select * from Students").ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public StudentDetails GetByID(int studid)
        {
            try
            {
                var result = _contxt.Students.FromSqlRaw<StudentDetails>($"select * from Students where StudentID={studid}");
                return result.ToList().FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

