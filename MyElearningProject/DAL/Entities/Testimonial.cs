using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
    public class Testimonial
    {
        public int TestimonialID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
    }
}