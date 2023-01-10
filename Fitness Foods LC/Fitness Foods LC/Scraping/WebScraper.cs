using Fitness_Foods_LC.Enumeradores;
using Fitness_Foods_LC.Models;
using Fitness_Foods_LC.Services;
using HtmlAgilityPack;

namespace Fitness_Foods_LC.Scraping
{
    public class WebScraper
    {
        public async Task scraping()
        {
            try
            {
                var listaProdutos = new List<Product>();

                var url = "https://world.openfoodfacts.org";

                HttpClient cliente = new HttpClient();

                HtmlDocument doc = new HtmlDocument();

                var html = await cliente.GetStringAsync(url);

                doc.LoadHtml(html);

                var subheaders = doc.DocumentNode.SelectSingleNode("//ul[@class='products']");

                var link = string.Empty;

                foreach (var elemento in subheaders.Descendants("a"))
                {
                    link = elemento.Attributes["href"].Value;
                    var nomeProduto = elemento.Attributes["title"].Value.Replace("&nbsp;", " ");
                    var url2 = "https://world.openfoodfacts.org" + link;

                    HttpClient cliente2 = new HttpClient();
                    HtmlDocument doc2 = new HtmlDocument();
                    var html2 = await cliente.GetStringAsync(url2);
                    doc2.LoadHtml(html2);

                    var produtos = doc2.DocumentNode.SelectSingleNode("//*[@id='product']");

                    Product prod = new Product();

                    prod.Code = produtos.Descendants().First(x => x.Id.Equals("barcode")).InnerText;
                    prod.Barcode = produtos.Descendants().FirstOrDefault(x => x.Id.Equals("barcode_paragraph")) != null ? produtos.Descendants().First(x => x.Id.Equals("barcode_paragraph")).InnerText.Replace("                                Barcode:  ", "").Replace("\n", "") : string.Empty;
                    prod.Status = EnumStatus.IMPORTED;
                    prod.Imported = DateTime.Now;
                    prod.Url = url2;
                    prod.ProductName = nomeProduto;
                    prod.Quantity = produtos.Descendants().FirstOrDefault(x => x.Id.Equals("field_quantity_value")) != null ? produtos.Descendants().First(x => x.Id.Equals("field_quantity_value")).InnerText : string.Empty;
                    prod.Categories = produtos.Descendants().FirstOrDefault(x => x.Id.Equals("field_categories_value")) != null ? produtos.Descendants().First(x => x.Id.Equals("field_categories_value")).InnerText : string.Empty;
                    prod.Packaging = produtos.Descendants().FirstOrDefault(x => x.Id.Equals("field_packaging_value")) != null ? produtos.Descendants().First(x => x.Id.Equals("field_packaging_value")).InnerText : string.Empty;
                    prod.Brands = produtos.Descendants().FirstOrDefault(x => x.Id.Equals("field_brands_value")) != null ? produtos.Descendants().First(x => x.Id.Equals("field_brands_value")).InnerText : string.Empty;
                    prod.ImageUrl = "https://static.openfoodfacts.org/images/products/" + SepararCodigo(produtos.Descendants().First(x => x.Id.Equals("barcode")).InnerText) + "/front_";

                    listaProdutos.Add(prod);

                    if (listaProdutos.Count >= 100)
                    {
                        break;
                    }
                }

                CadastrarProdutos(listaProdutos);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void CadastrarProdutos(List<Product> listaprodutos)
        {
            ProductServices productServices = new ProductServices();
            productServices.productRepository.ExcluirProdutos();
            productServices.productRepository.CadastrarProduto(listaprodutos);
        }


        public string SepararCodigo(string code)
        {
            if (code.Length <= 8)
            {
                return code;
            }

            return code.Substring(0, 3) + "/" + code.Substring(3, 3) + "/" + code.Substring(6, 3) + "/" + code.Substring(9, 4);
        }
    }

}

