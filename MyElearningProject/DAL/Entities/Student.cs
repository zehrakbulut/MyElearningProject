using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<CourseRegister> CourseRegisters { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Process> Processes { get; set; }
    }
}