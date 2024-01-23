using System;
using System.Collections.Generic;

namespace StudentDataAccessLayer
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentDetails> GetAllRecords();
        public StudentDetails GetByID(int id);
        public void Insert(StudentDetails detail);
        public void Update(int id, StudentDetails stud);
        public void Delete(int studid);
    }
}
