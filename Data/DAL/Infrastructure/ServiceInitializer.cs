using DotNetCoreAPIBoilerPlate.Data.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreAPIBoilerPlate.Data.DAL.Infrastructure
{
    public static class ServiceInitializer
    {
        public static void AddDAL(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnStr");
            services.AddDbContext<ApplicationEFContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
