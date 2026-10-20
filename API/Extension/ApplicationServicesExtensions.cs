using API.Helper;
using Domain.interfaces;
using Domain.interfaces.Services;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extension
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ConfigurationManager config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString,
                   builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IStudentServices, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<ISubjectRepository, SubjectRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(configuration =>
            {
                configuration.AddProfile<ProductMappingProfile>();
            });

            return services;
        }
    }
}
