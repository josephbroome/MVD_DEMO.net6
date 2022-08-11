using Dapper;
using MVD_DEMO.net6.Models;
using System.Data;

namespace MVD_DEMO.net6
{
    public class ProductRepository: IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new {id});
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @name, Price = @price , OnSale = @onsale, StockLevel = @stocklevel WHERE ProductID = @id",
             new { name = product.Name, price = product.Price,onsale= product.OnSale,stocklevel=product.StockLevel, id = product.ProductID });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, PRICE, ONSALE, STOCKLEVEL, CATEGORYID) VALUES (@name, @price, @Onsale, @Stocklevel, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, Onsale = productToInsert.OnSale, Stocklevel = productToInsert.StockLevel, categoryID = productToInsert.CategoryID });
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }

    }
}
