using PersonalCalendar.Models.Calendar;
using System.Data.Entity;

namespace PersonalCalendar.Data
{
    public class PlanDbContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Time> Times { get; set; }

        public PlanDbContext()
            : base("PlanDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
