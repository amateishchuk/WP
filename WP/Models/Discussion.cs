using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WP.Models
{
    public class Discussion
    {
        public Guid Id { get; set; }
        public Guid? AskerId { get; set; }
        [Required]
        public Guid ResponderId { get; set; }
        [Required]
        public string Question { get; set; }
        public string Response { get; set; }
        public virtual ICollection<Point> Points { get; set; }

        public Discussion()
        {
            Points = new List<Point>();
        }
    }
}