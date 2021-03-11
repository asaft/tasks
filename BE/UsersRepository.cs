
using usertasks.Contracts;
using usertasks.DAL;
using usertasks.Models;

namespace usertasks.BE
{
    public class UsersRepository : RepositoryBase<User>,IUsersRepository
    {
       public UsersRepository(RepositoryContext repositoryContext):base(repositoryContext)
       {
           
       }
    }
}