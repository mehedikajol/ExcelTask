using ExcelTask.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcelTask.Infrastructure.Contexts;

public class ExcelTaskDbContext : DbContext
{
    public ExcelTaskDbContext(DbContextOptions<ExcelTaskDbContext> options)
        : base(options)
    {

    }

    public DbSet<Allergies> Allergies { get; set; }
    public DbSet<Allergies_Detail> Allergies_Details { get; set; }
    public DbSet<Disease> Diseases { get; set; }
    public DbSet<NCD> NCDs { get; set; }
    public DbSet<NCD_Detail> NCD_Details { get; set; }
    public DbSet<Patient> Patients { get; set; }
}
