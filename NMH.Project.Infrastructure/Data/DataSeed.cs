using NMH.Project.Domain.Core.Abstraction;

namespace NMH.Project.Infrastructure.Data;

public static class DataSeed
{
    public static void Seed(NMHProjectDbContext dbContext)
    {
        SeedImages(dbContext);
        SeedSites(dbContext);
        SeedArticles(dbContext);
        SeedAuthors(dbContext);
    }

    private static void SeedArticles(NMHProjectDbContext dbContext)
    {

    }

    private static void SeedAuthors(NMHProjectDbContext dbContext)
    {

    }

    private static void SeedImages(NMHProjectDbContext dbContext)
    {

    }

    private static void SeedSites(NMHProjectDbContext dbContext)
    {

    }

    private static void SaveEntities<TEntity>(NMHProjectDbContext dbContext, params TEntity[] entities) where TEntity : BaseEntity
    {
        var ids = entities.Select(e => e.Id).ToArray();
        var existingIds = dbContext.Set<TEntity>().Where(x => ids.Contains(x.Id)).Select(x => x.Id).ToArray();

        var entitiesToAdd = entities.ExceptBy(existingIds, x => x.Id).ToArray();
        if (entitiesToAdd.Length > 0)
        {
            dbContext.AddRange(entitiesToAdd);
            dbContext.SaveChanges();
        }
    }
}