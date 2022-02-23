using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFitTimer.Models;

namespace MyFitTimer.Data
{
    public class MyFitTimerContext : DbContext
    {
        public MyFitTimerContext (DbContextOptions<MyFitTimerContext> options)
            : base(options)
        {
        }

        public DbSet<MyFitTimer.Models.TimerRun> TimerRuns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimerRun>().ToTable("TimerRun");
        }
    }
}
