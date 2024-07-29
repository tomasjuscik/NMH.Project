using Microsoft.EntityFrameworkCore;

namespace NMH.Project.Infrastructure.Data;

public class DbInit
{
    private readonly NMHProjectDbContext _dbContext;

    public DbInit(NMHProjectDbContext dbContext) => _dbContext = dbContext;

    public void Run()
    {
        RunMigrations();
        RunSeeds();
    }

    private void RunSeeds() => DataSeed.Seed(_dbContext);

    private void RunMigrations() => _dbContext.Database.Migrate();
}