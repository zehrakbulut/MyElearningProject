using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}