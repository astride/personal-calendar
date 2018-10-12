using PersonalCalendar.Models.Calendar;
using System.Data.Entity;

namespace PersonalCalendar.Data
{
    public class PlanDbContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public PlanDbContext() : base("PlanDb") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
