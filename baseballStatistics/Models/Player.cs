﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baseballStatistics.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Nickname { get; set; }

        [Required]
        public int Age { get; set; }

        public string Position { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}