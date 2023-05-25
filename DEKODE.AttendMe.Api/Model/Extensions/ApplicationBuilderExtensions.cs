using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DEKODE.AttendMe.Api.Model.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void MigrateDb(this IApplicationBuilder app, bool development = false)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<AttendMeDbContext>())
            {
                if (development)
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}