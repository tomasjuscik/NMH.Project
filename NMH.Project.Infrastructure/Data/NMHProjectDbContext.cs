namespace NMH.Project.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using NMH.Project.Domain.Entities;
using System.Reflection;

public class NMHProjectDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; } = null!;
    public DbSet<Author> Author { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<Site> Sites { get; set; } = null!;

    public NMHProjectDbContext(DbContextOptions<NMHProjectDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        ConfigureArticle(modelBuilder);
        ConfigureAuthor(modelBuilder);
        ConfigureImage(modelBuilder);
        ConfigureSite(modelBuilder);
        GlobalRules(modelBuilder);
    }

    private static void GlobalRules(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(string))
                {
                    var maxLength = property.GetMaxLength();
                    if (maxLength == null)
                    {
                        property.SetMaxLength(256);
                    }
                }
            }
        }
    }

    private void ConfigureArticle(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(article =>
        {
            article.HasKey(x => x.Id);
            article.HasIndex(x => x.Title);
            article.HasMany(x => x.Authors).WithMany();
            article.HasOne(e => e.Site).WithMany();
        });
    }

    private void ConfigureAuthor(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(author =>
        {
            author.HasKey(x => x.Id);
            author.HasIndex(x => x.Name).IsUnique();
            author.HasOne(x => x.Image)
            .WithOne()
            .HasForeignKey<Author>(e => e.Id);
        });
    }

    private void ConfigureImage(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>(image =>
        {
            image.HasKey(x => x.Id);
        });
    }

    private void ConfigureSite(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Site>(site =>
        {
            site.HasKey(x => x.Id);
        });
    }
}