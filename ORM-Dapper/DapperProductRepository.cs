using System;
using System.Data;
using Dapper;

namespace ORM_Dapper                        //confirm
{
	public class DapperProductRepository : IProductRepository
	{   //set up connection
        private readonly IDbConnection _connection;

		public DapperProductRepository(IDbConnection connection)
		{
            _connection = connection;
		}

        public void CreateProduct(string name, double price, int CategoryID)
        {
            _connection.Execute("INSERT INTO products(Name,Price,CategoryID)" +
                "VALUES (@name,@price,@categoryID);",
                new { name = name, price = price, CategoryID = CategoryID});
        }

      

        public IEnumerable<Product_Class> GetAllProducts()
        {
            return _connection.Query<Product_Class>("SELECT * FROM products;");
        }
    }
}

