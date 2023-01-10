using Fitness_Foods_LC.Models;
using IKVM.Attributes;

namespace Fitness_Foods_LC.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        Product GetProduct(string code);
        List<Product> GetProducts();
        void CadastrarProduto(List<Product> listaProdutos);
        void ExcluirProdutos();
    }
}
