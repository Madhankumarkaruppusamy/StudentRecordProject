using System;
using System.Collections.Generic;

namespace StudentDataAccessLayer
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentDetails> GetAllRecords();
        public StudentDetails GetByid(int Id);
        public void Insert(StudentDetails detail);
        public void Update(int Id, StudentDetails value);
        public void Delete(int Id);
    }
}
