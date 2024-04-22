using System;
namespace ORM_Dapper
{
	public interface IProductRepository
	{
		public IEnumerable<Product_Class> GetAllProducts();


		public void CreateProduct(string name, double price, int CategoryID);
	}


	
}

