
using Domain.Entities.CaseMgnt;
using Domain.Entities.ClaimMngt;
using Domain.Entities.DocumentMngt;
using Domain.Entities.RecoverMngt;
using Domain.Entities.RefinanceMngt;
using Domain.Entities.RestructureMgnt;
using Domain.Entities.ServiceMngt;
using Domain.Entities.UserMngt;
using Infrastructure.Persistence.Configuration;
using LoginTestAPI.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Case> Cases { get; set; }
    public DbSet<Employees> Employees { get; set; }
    public DbSet<Restructure> Restructures { get; set; }
    public DbSet<Recover> Recovers { get; set; }

    public DbSet<Documents> Documents { get; set; }

    public DbSet<Service> Services { get; set; }

    public DbSet<Region> Regions { get; set; }

    public DbSet<ServiceProvider> ServiceProviders { get; set; }

    public DbSet<ServiceBooking> ServiceBookings { get; set; }

    public DbSet<ApplicationUser> ApplicationUser { get; set; }

    public DbSet<Internal> Internals { get; set; }
    public DbSet<External> Externals { get; set; }

    public DbSet<Refinance> Refinances { get; set; }

    public DbSet<BookingDocument> BookingDocuments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(CaseConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(RestructureConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(ServiceConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(RegionConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(ServiceProviderConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(ServiceBookingConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(RefinanceConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(InternalConfiguration).Assembly);
        builder.ApplyConfigurationsFromAssembly(typeof(ExternalConfiguration).Assembly);
    }
}


