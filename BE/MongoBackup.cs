using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using usertasks.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace usertasks.BE
{
    public class MongoBackup : IMongoBackup
    {
        const string TASK_COLLECTION = "tasks_collections";
        const int DAY = 1;
        private IMongoCollection<Models.Task> _tasksCollection;
        private ITasksRepository _repository;
        private List<Models.Task> _lastUpdatedTasksList;

        public MongoBackup(IMongoSettings settings, ITasksRepository repository)
        {
            _repository = repository;
            var client = new MongoClient(settings.MongoConnectionString);
            var database = client.GetDatabase(settings.MongoDbName);
            _tasksCollection = database.GetCollection<Models.Task>(TASK_COLLECTION);
        }
        public Task DoBackUp()
        {
            SetLastUpdatedTasks();

            BackupNewData();

            return Task.CompletedTask;

        }

        private void BackupNewData()
        {
            
            foreach(var item in _lastUpdatedTasksList)
            {
                _tasksCollection.ReplaceOne(r => r.Id == item.Id,item);
              
                var result =_tasksCollection.FindOneAndReplace<Models.Task>(t => t.Id == item.Id,item);
                if(result == null)
                {
                     _tasksCollection.InsertOne(item);
                }

            }
        
        }

        private void SetLastUpdatedTasks()
        {
            var minDate = DateTime.Now.AddDays(-DAY);
            Expression<Func<Models.Task, bool>> expression = deleg => deleg.UpdatedAt > minDate;
            var results = _repository.FindByCondition(expression);
            if (results.Any())
            {
                _lastUpdatedTasksList = results.ToList();
            }


        }

        public DateTime GetLastTimeBackup()
        {
            throw new NotImplementedException();
        }
    }
}