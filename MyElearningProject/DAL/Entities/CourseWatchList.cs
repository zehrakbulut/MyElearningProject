using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
    public class CourseWatchList
    {
        public int CourseWatchListID { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

        public string VideoUrl { get; set; }
    }
}