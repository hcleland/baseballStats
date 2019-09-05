using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baseballStatistics.Models
{
    public class CoachTeam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
