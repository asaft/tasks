using MongoDB.Driver;
using usertasks.Models;

namespace usertasks.DAL
{
    public class mongo
    {
        public void foo()
        {
              var mongo = new MongoClient();
              var db = mongo.GetDatabase("UsersTasksBackupDB");
              var collection = db.GetCollection<Task>("TasksCollection");
              
              
        }
    }
}