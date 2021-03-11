namespace usertasks.Contracts
{
    public interface IMongoSettings
    {
         public string MongoConnectionString { get; set; }
         public string MongoDbName { get; set; }
    }
}