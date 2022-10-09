using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
  public class BaseDbContext:DbContext
  {
    protected IConfiguration Configuration { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<Technology> Technologies { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions)
    {
      Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
    { 

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ProgrammingLanguage>(a =>
      {
        a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
        a.Property(p => p.Id).HasColumnName("Id");
        a.Property(p => p.Name).HasColumnName("Name");
        a.Property(p => p.IsDelete).HasColumnName("IsDelete");
        a.HasMany(p => p.Technologies);
      });

      modelBuilder.Entity<Technology>(a =>
      {
        a.ToTable("Technologies").HasKey(k => k.Id);
        a.Property(p => p.Id).HasColumnName("Id");
        a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
        a.Property(p => p.Name).HasColumnName("Name");
        a.Property(p => p.IsDelete).HasColumnName("IsDelete");
        a.HasOne(p => p.ProgrammingLanguage);
      });

      ProgrammingLanguage[] programLanguageEntitySeeds = { new(1,"C#",false), new(2,"Java", false) };
      modelBuilder.Entity<ProgrammingLanguage>().HasData(programLanguageEntitySeeds);

      Technology[] technologiesEntitySeeds = { new(1, 1, "ASP.NET", false), new(2, 1, "WPF", false), new(3, 2, "Spring", false) };
      modelBuilder.Entity<Technology>().HasData(technologiesEntitySeeds);
    }
  }
}
