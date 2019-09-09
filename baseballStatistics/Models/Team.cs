using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baseballStatistics.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        public string Name { get; set; }

        [Display(Name = "Team Mascot")]
        public string Mascot { get; set; }
         
        [Display(Name = "Affiliated Team")]
        public string TeamAffiliation { get; set; }

        //[Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Player> Players { get; set; }

    }
}
