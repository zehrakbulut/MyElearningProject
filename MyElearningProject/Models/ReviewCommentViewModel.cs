using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyElearningProject.Models
{
    public class ReviewCommentViewModel
    {
        [Required]
        public int CourseID { get; set; }

        [Required]
        public int ReviewScore { get; set; }
        public int ReviewID { get; set; }
        public int StudentID { get; set; }
        public int CommentID { get; set; }

        [Required]
        public string CommentText { get; set; }
    }
}