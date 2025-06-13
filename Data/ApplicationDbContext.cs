using GamingStore.API.Models;
using GamingStore.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Teclado> Teclados { get; set; }
    public DbSet<Mouse> Mouses { get; set; }
    public DbSet<Headset> Headsets { get; set; }
    }
}
