using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
    public class Process
    {
        public int ProcessID { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}