using Fitness_Foods_LC.Models;
using Fitness_Foods_LC.Repositories;
using Fitness_Foods_LC.Scraping;
using Fitness_Foods_LC.Services;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sun.awt.image;
using sun.invoke.empty;
using System.Linq;
using System.Net;

namespace Fitness_Foods_LC.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Fullstack Challenge 20201026";
        }

        [HttpGet]
        [Route("products/{code}")]
        public Product GetCode(string code)
        {
            ProductServices productServices = new ProductServices();
            return productServices.productRepository.GetProduct(code); 
        }

        [HttpGet]
        [Route("products")]
        public List<Product> GetProducts()
        {
            ProductServices productServices = new ProductServices();
            return productServices.productRepository.GetProducts();
        }
    }
}
