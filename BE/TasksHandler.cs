using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using usertasks.Contracts;
using usertasks.Helpers;
using usertasks.Models;

namespace usertasks.BE
{
    public class TasksHandler : DatabaseHandler<Task>
    {
        private ITasksRepository _repository;

        public TasksHandler(ITasksRepository repository)
        {
            _repository = repository;
        }
        public override Task Add(Task entity)
        {
            var validator = new TaskValidatorHelper(entity);
            if (validator.CanAdd())
            {
                _repository.Create(entity);
                _repository.Save();
                return entity;
            }

            return null;
        }

        public override Task Update(Task entity)
        {
            var validator = new TaskValidatorHelper(entity);
            if (validator.CanUpdate())
            {
                _repository.Update(entity);
                _repository.Save();
            }

            return entity;
        }

        public override IEnumerable<Task> GET()
        {
            return _repository.FindAll();
        }

        public override IEnumerable<Models.Task> GET(int id)
        {
            Expression<Func<Models.Task, bool>> expression = deleg => deleg.UserId == id;
            var results = _repository.FindByCondition(expression);
            if (results.Any())
            {
                return results;
            }

            return null;
        }

        public override bool Delete(int id)
        {
            try
            {
                var task = _repository.Find(id);
                if (task != null)
                {
                    _repository.Delete(task);
                    _repository.Save();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }




        }
    }
}