
using usertasks.Contracts;
using usertasks.DAL;
using usertasks.Models;

namespace usertasks.BE
{
    public class TasksRepository : RepositoryBase<Task>,ITasksRepository
    {
       public TasksRepository(RepositoryContext repositoryContext):base(repositoryContext)
       {
           
       }
    }
}