using Microsoft.EntityFrameworkCore;
using openComputingLab.Models;
namespace openComputingLab.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.UseSerialColumns();

    }

    public DbSet<Band> Bands { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }

}