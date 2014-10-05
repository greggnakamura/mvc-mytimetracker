using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MVC_MyTimeTracker.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
