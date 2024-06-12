using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationAPI.Controllers
{
    public class DBContext
    {
        public SqlConnection con;

        public DBContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            con = new SqlConnection(configuration["ConnectionStrings:EDSConn"]);
        }
    }
}