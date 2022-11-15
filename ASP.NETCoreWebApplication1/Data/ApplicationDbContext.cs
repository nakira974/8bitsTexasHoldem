using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using TexasHoldem.Models;

namespace ASP.NETCoreWebApplication1.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }
    
    public DbSet<ApplicationUser> AspNetUsers { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ApplicationUser>()
            .HasOne(e => e.PlayerAccount)
            .WithOne(e => e.User);
        
        modelBuilder.Entity<Player>()
            .HasOne(e => e.User)
            .WithOne(e => e.PlayerAccount)
            .OnDelete(DeleteBehavior.Cascade);
    }
}