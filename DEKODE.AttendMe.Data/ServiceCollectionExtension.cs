using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DEKODE.AttendMe.Data.Model
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAttendMeDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AttendMeDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                    .UseSqlite(connectionString)
                    );

            return services;
        }
    }
}
