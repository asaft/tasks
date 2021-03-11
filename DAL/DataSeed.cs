namespace usertasks.DAL
{
    using Npgsql;
    using usertasks.Models;
    public class DataSeed
    {
        private string _connStr;

        public DataSeed(string connStr)
        {
            _connStr = connStr;
        }
        public  void InsertUser(User user)
        {
            using var con = new NpgsqlConnection(_connStr);
            con.Open();

            var sql = "INSERT INTO \"Users\" (\"Id\",\"FirstName\",\"LastName\",\"UserName\",\"Password\") " +
            $"VALUES('{user.Id}','{user.FirstName}','{user.LastName}','{user.UserName}','{user.Password}') " +
            $"ON CONFLICT (\"Id\") DO UPDATE SET \"FirstName\"='{user.FirstName}',\"LastName\"='{user.LastName}'," +
            $"\"UserName\"='{user.UserName}',\"Password\"='{user.Password}'";

            using var cmd = new NpgsqlCommand(sql, con);
            cmd.ExecuteScalar();

        }

    }
}