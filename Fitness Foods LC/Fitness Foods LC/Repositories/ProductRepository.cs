using Fitness_Foods_LC.Interfaces;
using Fitness_Foods_LC.Models;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Foods_LC.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;

        public ProductRepository(bool saveChanges = true)
        {
            this._context = new ProductContext();
        }

        public void CadastrarProduto(List<Product> listaProdutos)
        {
            foreach (var produto in listaProdutos)
            {
                _context.Product.Add(produto);
            }
            _context.SaveChanges();
        }

        public void ExcluirProdutos()
        {
            _context.Product.ExecuteDelete();
        }

        public Product GetProduct(string code)
        {
            return _context.Product.Find(code); ;
        }

        public List<Product> GetProducts()
        {
            return _context.Product.ToList();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
