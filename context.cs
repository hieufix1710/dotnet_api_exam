
using WebApi.Models;

namespace DataAccess;
public class DataContext : DbContext
{

  public DataContext(DbContextOptions<DataContext> options) : base(options){}

  protected override void OnModelCreating(ModelBuilder modelBuilder){
    // modelBuilder.Entity<User>().HasMany(b => b.Articles).WithOne().HasForeignKey(p => p.Images);
    // modelBuilder.Entity<Image>().HasOne(b => b.Article).WithMany(g => g.Images).HasForeignKey(s => s.Article).OnDelete(DeleteBehavior.Cascade);;
  }

  public DbSet<User>? Users { get; set; }

  public DbSet<Article>? Articles { get; set; }

  public DbSet<Image>? Images { get; set; }

}