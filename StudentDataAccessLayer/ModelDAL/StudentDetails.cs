using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataAccessLayer
{
    public class StudentDetails
    {
        
        public StudentDetails()
        {
            Subject = "-1";
            DOB = DateTime.Now;
        }
        [Key]
        public int StudentID {get;set;}
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }

    }
}
