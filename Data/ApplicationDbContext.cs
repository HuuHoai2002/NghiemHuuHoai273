using NghiemHuuHoai273.Models;
using Microsoft.EntityFrameworkCore;

namespace NghiemHuuHoai273.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CompanyNHH273> Companys { get; set; }
  }
}