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

        public int AtBat { get; set; }

        public int Hit { get; set; }

        public int Single { get; set; }

        public int Double { get; set; }

        public int Triple { get; set; }

        public int HomeRun { get; set; }

        public int RunsBattedIn { get; set; }

        public int RunsScored { get; set; }

        public int Walk { get; set; }

        public int Strikeout { get; set; }

        public virtual Player Player { get; set; }
    }
}
