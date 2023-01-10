using Fitness_Foods_LC.Repositories;

namespace Fitness_Foods_LC.Services
{
    public class ProductServices
    {
        public ProductRepository productRepository { get; set; }

        public ProductServices()
        {
            productRepository = new ProductRepository();
        }
    }
}
