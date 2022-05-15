using BH.Assessment.Domain.Common;
using BH.Assessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BH.Assessment.Persistence;

public class BhAssessmentContext : DbContext
{
    public BhAssessmentContext(DbContextOptions<BhAssessmentContext> options) : base(options)
    {
        ChangeTracker.StateChanged += TrackingAuditInformation;
        ChangeTracker.Tracked += TrackingAuditInformation;
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseInMemoryDatabase("BHAssessment");
    //}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BhAssessmentContext).Assembly);
        SeedingData(modelBuilder);

        // base.OnModelCreating(modelBuilder);
    }

    private static void SeedingData(ModelBuilder modelBuilder)
    {
        var concreteCustomerId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");

        modelBuilder.Entity<Customer>().HasData(new Customer
        {
            Id = concreteCustomerId,
            Name = "Mustafa",
            Surname = "Wali",
            Balance = 5000.6,
            CreatedDate = DateTimeOffset.Now,
            CreatedBy = "Test User",
            LastModifiedDate = DateTimeOffset.Now,
            LastModifyBy = "Test User"
        });
    }

    private static void TrackingAuditInformation(object sender, EntityEntryEventArgs e)
    {
        if (e.Entry.Entity is AuditableEntity entity)
            switch (e.Entry.State)
            {
                case EntityState.Modified:
                    entity.LastModifiedDate = DateTime.Now;
                    entity.LastModifyBy = "Test User";
                    break;
                case EntityState.Added:
                    entity.CreatedDate = DateTime.UtcNow;
                    entity.CreatedBy = "Test User";
                    entity.LastModifyBy = String.Empty;
                    entity.LastModifiedDate = default;

                    break;
            }
    }

    //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
    //    CancellationToken cancellationToken = new())
    //{
    //    //var entries = ChangeTracker.Entries<AuditableEntity>().ToList();
    //    //var r = "mustafa";
    //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
    //        switch (entry.State)
    //        {
    //            case EntityState.Modified:
    //                entry.Entity.LastModifiedDate = DateTime.Now;
    //                break;
    //            case EntityState.Added:
    //                entry.Entity.CreatedDate = DateTime.Now;
    //                break;
    //        }

    //    return base.SaveChangesAsync(cancellationToken);
    //}
}