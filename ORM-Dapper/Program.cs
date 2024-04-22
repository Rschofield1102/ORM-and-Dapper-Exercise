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

            var repo = new DapperProductRepository(conn);

            Console.WriteLine("Name of new product?");
            var productsName = Console.ReadLine();
            Console.WriteLine("Price of product?");
            var pricess = double.Parse(Console.ReadLine());
            Console.WriteLine("CategoryID 1-10");
            var cateG = int.Parse(Console.ReadLine());
            

           repo.CreateProduct(productsName,pricess,cateG);

            var myList = repo.GetAllProducts();

            foreach(var item in myList)
            {
                
                Console.WriteLine(item.Name);
                Console.WriteLine(item.OnSale);
                Console.WriteLine();
            }




            foreach (Department item in myDepartments)
            {
                Console.WriteLine(item.DepartmentID);
                Console.WriteLine(item.name);
                Console.WriteLine();
            }





        }
    }
}
