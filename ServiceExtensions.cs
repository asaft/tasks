using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using usertasks.BE;
using usertasks.Contracts;
using usertasks.Crons;

namespace usertasks
{
    public static class ServiceExtensions
    {
        public static void ConfigurePostgreSQLContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:MyWebApiConection"];
            services.AddEntityFrameworkNpgsql().AddDbContext<RepositoryContext>(opt =>
                  opt.UseNpgsql(config.GetConnectionString("MyWebApiConection"), b => b.MigrationsAssembly("usertasks")));

        }

        public static void ConfigureMongoDB(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoSettings>(
            config.GetSection(nameof(MongoSettings)));

            services.AddSingleton<IMongoSettings>(sp =>
            sp.GetRequiredService<IOptions<MongoSettings>>().Value);
        }

        public static void ConfigureDependenciesInjections(this IServiceCollection services)
        {
            services.AddScoped<ITasksRepository, TasksRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        public static void ConfigureCronJobs(this IServiceCollection services)
        {
            services.AddSingleton<IJobFactory, TasksJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            services.AddSingleton<BackupDBJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(BackupDBJob),
                cronExpression: "0 */30 * * * ?"));
        }
    }
}