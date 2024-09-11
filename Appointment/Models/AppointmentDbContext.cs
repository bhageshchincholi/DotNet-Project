using Microsoft.EntityFrameworkCore;

namespace Appointment.Models
{
    public class AppointmentDbContext : DbContext
    { 
        public AppointmentDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Appointments> appointments { get; set;}

        public DbSet<User> users { get; set;}
    }
}
