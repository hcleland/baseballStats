using System;
using System.Collections.Generic;
using System.Text;
using baseballStatistics.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace baseballStatistics.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<BattingStats> Stats { get; set; }
        public DbSet<FieldingStats> FieldingStats { get; set; }
        public DbSet<CoachTeam> CoachTeam { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Ima",
                LastName = "Parent",
                UserName = "parent@mail.com",
                NormalizedUserName = "PARENT@MAIL.COM",
                Phone = "615-555-5555",
                Email = "parent@mail.com",
                NormalizedEmail = "PARENT@MAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                IsCoach = false
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "P@r3nt");
            builder.Entity<ApplicationUser>().HasData(user);

            Player player = new Player
            {
                Id = 1,
                FirstName = "Johnny",
                LastName = "Jones",
                Nickname = "JJ",
                Age = 9,
                Position = "Shortstop",
                ApplicationUserId = user.Id,
                TeamId = 1
            };

            builder.Entity<Player>().HasData(player);

            Team team = new Team
            {
                Id = 1,
                Name = "The Hooks", 
                Mascot = "Fish Hook",
                TeamAffiliation = "Houston Astros",
                ApplicationUserId = user.Id
            };

            builder.Entity<Team>().HasData(team);

            CoachTeam coachTeam = new CoachTeam
            {
                Id = 1,
                ApplicationUserId = user.Id,
                TeamId = 1
            };

            builder.Entity<CoachTeam>().HasData(coachTeam);

            BattingStats battingStats = new BattingStats
            {
                Id = 1,
                PlayerId = 1,
                GameDate = new DateTime(2019, 9, 5),
                AtBat = 3,
                Hit = 2,
                Single = 2,
                Double = 0,
                Triple = 0,
                HomeRun = 0,
                RunsBattedIn = 1,
                RunsScored = 1,
                Walk = 0,
                Strikeout = 0
            };

            builder.Entity<BattingStats>().HasData(battingStats);

            FieldingStats fieldingStats = new FieldingStats
            {
                Id = 1,
                PlayerId = 1,
                GameDate = new DateTime(2019, 9, 5),
                Assist = 0,
                Error = 1,
                Putout = 1,
                DoublePlay = 0
            };

            builder.Entity<FieldingStats>().HasData(fieldingStats);
        }
    }
}
