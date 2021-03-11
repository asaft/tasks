using System;
using System.Threading.Tasks;

namespace usertasks.Contracts
{
    public interface IMongoBackup
    {
         DateTime GetLastTimeBackup();
         Task DoBackUp();
    }
}