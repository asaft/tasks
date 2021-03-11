using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using usertasks.BE;
using usertasks.Contracts;

namespace usertasks.Crons
{
    public class BackupDBJob : IJob
    {
        private readonly ILogger<BackupDBJob> _logger;
        private readonly IServiceProvider _service;

        public BackupDBJob( ILogger<BackupDBJob> logger,IServiceProvider service)
        {
            _logger = logger;
             _service = service;
        }
        public Task Execute(IJobExecutionContext context)
        {
            
            using(var scope = _service.CreateScope())
            {
                var mongoSettings = _service.GetService<IMongoSettings>();
                var tasksRepository = scope.ServiceProvider.GetRequiredService<ITasksRepository>();

                var mongoBackup = new MongoBackup(mongoSettings,tasksRepository);
                mongoBackup.DoBackUp();
            }
            _logger.LogInformation("loggin now " + DateTime.Now.ToString());
            return Task.CompletedTask;
        }
    }
}