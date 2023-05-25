using DEKODE.AttendMe.Data.Model.Entities;
using DEKODE.AttendMe.Data.Model.Relationships;
using Microsoft.EntityFrameworkCore;

namespace DEKODE.AttendMe.Data.Model
{
    public class AttendMeDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // Support for complex types is currently on the backlog
        // https://stackoverflow.com/questions/31906950/using-complextype-in-entity-framework-core
        // modelBuilder.ComplexType<Address>();
        // EF Core 3.1 - [Owned], Ownes, OwnsOne

        //public AttendMeDbContext(DbContextOptions<AttendMeDbContext> options) : base(options)
        //{
        //}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql(
            //    @"Server=127.0.0.1;Port=3306;Database=attendme_school_db;Uid=root;Pwd=Saathiva2021;pooling=false");

            // optionsBuilder.UseSqlite("Filename=attendme_db.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Manual configuration of relationship - Fluent API
            //modelBuilder.Entity<Subscription>()
            //    .HasOne(s => s.Account)
            //    .WithMany(a => a.Subscriptions)
            //    .HasForeignKey(s => s.AccountId)
            //    .IsRequired();

            // modelBuilder.Ignore<Address>();

            // Apply all configuration in the assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttendMeDbContext).Assembly);
        }
    }
}
