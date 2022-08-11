using MVD_DEMO.net6.Models;

namespace MVD_DEMO.net6
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public Product GetProduct(int id);

    }
}
