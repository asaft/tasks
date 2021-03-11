using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using usertasks.BE;
using usertasks.Contracts;

namespace usertasks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
     
        private readonly ITasksRepository _repository;

        public TasksController(ITasksRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userId}")]
        public Task<IEnumerable<Models.Task>> Get(int userId)
        {
           var taskHandler = new TasksHandler(_repository);
           return Task.Run(()=>taskHandler.GET(userId));
        }

        [HttpPost]
        public Task<Models.Task> Post(Models.Task task)
        {
           var taskHandler = new TasksHandler(_repository);
           return Task.Run(()=>taskHandler.Add(task));
        }
        [HttpPut]
        public Task<Models.Task> Put(Models.Task task)
        {
           var taskHandler = new TasksHandler(_repository);
           return Task.Run(()=>taskHandler.Update(task));
        }

        [HttpDelete("{id}")]
        public Task<bool> Delete(int id)
        {
           var taskHandler = new TasksHandler(_repository);
           return Task.Run(()=>taskHandler.Delete(id));
        }
    }
}
