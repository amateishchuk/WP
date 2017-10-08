using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WP.Models
{
    public class Point
    {
        public Guid Id { get; set; }
        [Required]
        public Guid JudgeId { get; set; }
        public Rate PointRate { get; set; }
        public Guid DiscussionId { get; set; }
        public virtual Discussion Discussion { get; set; }
    }
    public enum Rate
    {
        Negative,
        Positive
    }
}