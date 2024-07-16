using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using JobMaster.Infrastructure.Common;

namespace JobMaster.Infrastructure;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<JobMasterDbContext>();
        if (dbContext.Database.GetPendingMigrations().Any())
            dbContext.Database.Migrate();
    }
}