using System;
using System.Collections.Generic;

namespace StudentDataAccessLayer
{
    public interface IStudentRepository
    {
        public IEnumerable<StudentDetails> GetAllRecords();
        public StudentDetails GetByID(int id);
        public void InsertStudent(StudentDetails detail);
        public void UpdateStudent(int id, StudentDetails stud);
        public void DeleteStudent(int studid);
    }
}
