using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baseballStatistics.Models
{
    public class FieldingStats
    {
        [Key]
        public int Id { get; set; }
        public int PlayerId { get; set; }

        [Required]
        [Display(Name = "Game Date")]
        [DataType(DataType.Date)]
        public DateTime GameDate { get; set; }

        [Display(Name = "Assists")]
        public int Assist { get; set; }

        [Display(Name = "Errors")]
        public int Error { get; set; }

        [Display(Name = "Putouts")]
        public int Putout { get; set; }

        [Display(Name = "Double Plays")]
        public int DoublePlay { get; set; }

        public virtual Player Player { get; set; }
    }
}
