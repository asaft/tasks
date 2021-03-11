using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace usertasks.Crons
{
      public class TasksJobFactory : IJobFactory
    {
          private readonly IServiceProvider _serviceProvider;
        public TasksJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
           return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
 
        }

        public void ReturnJob(IJob job)
        {
         
        }
    }

   
}