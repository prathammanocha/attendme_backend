using DEKODE.AttendMe.Api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DEKODE.AttendMe.Api.Model
{
    public class AttendMeDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        // Support for complex types is currently on the backlog
        // https://stackoverflow.com/questions/31906950/using-complextype-in-entity-framework-core
        // modelBuilder.ComplexType<Address>();
        // EF Core 3.1 - [Owned], Ownes, OwnsOne

        public AttendMeDbContext(DbContextOptions<AttendMeDbContext> options) : base(options)
        {
        }

        //public DbSet<Account> Accounts { get; set; }
        //public DbSet<AccountUser> AccountUsers { get; set; }
        //public DbSet<AccSbscrptn> AccSbscrptns { get; set; }
        //public DbSet<AppDevice> AppDevice { get; set; }
        public DbSet<Compliance> Compliances { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrganisationUser> OrganisationUsers { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<PatronCompliance> PatronCompliances { get; set; }
        public DbSet<PatronStudent> PatronStudents { get; set; }
        public DbSet<PatronType> PatronTypes { get; set; }
        public DbSet<Parents> Parents { get; set; } //Add this line for Parents Entity
        public DbSet<Relatives> Relatives { get; set; } // Add this line for Relatives entity
        public DbSet<SbscrptnType> SbscrptnTypes { get; set; }
        public DbSet<Staff> StaffMembers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentIncident> StudentIncidents { get; set; }
        public DbSet<StudentIncidentAction> StudentIncidentActions { get; set; }
        public DbSet<StudentIncidentLog> StudentIncidentLogs { get; set; }
        public DbSet<StudentIncidentSymptom> StudentIncidentSymptoms { get; set; }
        public DbSet<StudentLog> StudentLogs { get; set; }
        public DbSet<StudentLogReason> StudentLogReasons { get; set; }
        //public DbSet<User> Userw { get; set; }
        public DbSet<VisitorLog> VisitorLogs { get; set; }



        // WARNING: This is called with each new request.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseMySql(
        //    //    @"Server=127.0.0.1;Port=3306;Database=attendme_school_db;Uid=root;Pwd=Saathiva2021;pooling=false");

        //    // optionsBuilder.UseSqlite("Filename=attendme_db.db");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Ignore<Address>();

            // Apply all configuration in the assembly.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AttendMeDbContext).Assembly);
            modelBuilder.Seed();
            modelBuilder.Entity<Relatives>().HasKey(r => r.StudentId);
        }
    }
}
