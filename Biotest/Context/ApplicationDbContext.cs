using System.Linq.Expressions;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Context
{
    public class ApplicationDbContext : DbContext
    {

        // All DbSets go here
        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<AnalysisType> AnalysisType { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeePosition> EmployeePosition { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<GeneticTest> GeneticTest { get; set; }
        public DbSet<GeneticTestType> GeneticTestType { get; set; }
        public DbSet<GeneticVariant> GeneticVariant { get; set; }
        public DbSet<GeneticVariantType> GeneticVariantType { get; set; }
        public DbSet<Genotype> Genotype { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<PredictedEffect> PredictedEffect { get; set; }
        public DbSet<Sample> Sample { get; set; }
        public DbSet<SampleSource> SampleSource { get; set; }
        public DbSet<SampleType> SampleType { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        // Filter all entities with IsActive property
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasQueryFilter(p => p.IsActive);
        }
    }
}
