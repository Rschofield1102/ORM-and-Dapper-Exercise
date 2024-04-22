using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace ORM_Dapper
{


    public class Program
    {
        static void Main(string[] args)
        {


            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            DapperDepartmentRepository instance = new DapperDepartmentRepository(conn);
            IEnumerable<Department> myDepartments = instance.GetAllDepartments();

            foreach(Department item in myDepartments)
            {
                Console.WriteLine(item.DepartmentID);
                Console.WriteLine(item.name);
                Console.WriteLine();
            }





        }
    }
}
