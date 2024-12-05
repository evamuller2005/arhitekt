using Arhitekt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arhitekt.Data;


public class ArhitektContext : IdentityDbContext<ApplicationUser>
{

public ArhitektContext(DbContextOptions<ArhitektContext> options) : base(options)
{

}

public DbSet<User> Users { get; set; }
public DbSet<Architect> Architects { get; set; }
public DbSet<Project> Projects { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
            base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<User>().ToTable("User");
    modelBuilder.Entity<Architect>().ToTable("Architect");
    modelBuilder.Entity<Project>().ToTable("Project");
}

}