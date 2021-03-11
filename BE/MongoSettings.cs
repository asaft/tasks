using usertasks.Contracts;

namespace usertasks.BE
{
    public class MongoSettings : IMongoSettings
    {
        public string MongoConnectionString { get; set; }
        public string MongoDbName { get ; set ; }
    }
}