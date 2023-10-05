using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace StudentsDbApp.Services.DBHelper
{
    public class DBUtil
    {
        private DBUtil() { }

        public static SqlConnection? GetConnection()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();
            string? url = configuration.GetConnectionString("DefaultConnection");
            try
            {
                SqlConnection conn = new(url);
                return conn;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
