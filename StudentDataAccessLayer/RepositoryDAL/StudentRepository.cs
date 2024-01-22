using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
       
        public IEnumerable<StudentDetails> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public StudentDetails GetByid(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(StudentDetails detail)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, StudentDetails value)
        {
            throw new NotImplementedException();
        }
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
