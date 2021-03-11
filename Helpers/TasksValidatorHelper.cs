using usertasks.DAL;
using usertasks.Models;

namespace usertasks.Helpers
{
    public class TaskValidatorHelper : IValidatorHelper
    {
        private Task _task;

        public TaskValidatorHelper(Task task)
        {
            _task = task;
        }

        public bool CanAdd()
        {
            if(_task == null)
            {
                return false;
            }

            if(_task.Title == null || _task.Title == "")
            {
                return false;
            }

            if(_task.UserId == 0)
            {
                return false;
            }

            return true;
        }

        public bool CanUpdate()
        {
            if(!this.CanAdd()|| _task.Id == 0 )
            {
                return false;
            }

            return true;
        }
    }
}