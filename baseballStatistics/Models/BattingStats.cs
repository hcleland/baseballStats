using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baseballStatistics.Models
{
    public class BattingStats
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [Required]
        [Display(Name = "Game Date")]
        [DataType(DataType.Date)]
        public DateTime GameDate { get; set; }

        [Display(Name = "At Bats")]
        public int AtBat { get; set; }

        [Display(Name = "Hits")]
        public int Hit { get; set; }

        [Display(Name = "Singles")]
        public int Single { get; set; }

        [Display(Name = "Doubles")]
        public int Double { get; set; }

        [Display(Name = "Triples")]
        public int Triple { get; set; }

        [Display(Name = "Homeruns")]
        public int HomeRun { get; set; }

        [Display(Name = "Runs Batted In")]
        public int RunsBattedIn { get; set; }

        [Display(Name = "Runs Scored")]
        public int RunsScored { get; set; }

        [Display(Name = "Walks")]
        public int Walk { get; set; }

        [Display(Name = "Strikeouts")]
        public int Strikeout { get; set; }

        public virtual Player Player { get; set; }
    }
}
