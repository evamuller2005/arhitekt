namespace Arhitekt.Data;
using Arhitekt.Models;

using Microsoft.EntityFrameworkCore;

public class ArhitektContext : DbContext
{

public ArhitektContext(DbContextOptions<ArhitektContext> options) : base(options)
{

}

public DbSet<User> Users { get; set; }
public DbSet<Architect> Architects { get; set; }
public DbSet<Project> Projects { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
modelBuilder.Entity<User>().ToTable("User");
modelBuilder.Entity<Architect>().ToTable("Architect");
modelBuilder.Entity<Project>().ToTable("Project");
}

}