using App3.API;
using App3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Service
{
    public class ProductService : IProductService
    {
        private const string ProductDetailsAPI = "https://azdemo.getswift.asia/rest/V1/products/";
        public async Task<Product> GetProductDetails(string sku)
        {
            string queryString = ProductDetailsAPI+sku;
            dynamic result = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            Product product = new Product();
            if (result != null)
            {
                product.Id = result["id"];
                product.SKU = result["sku"];
                product.Name = result["name"];
                product.Price = result["price"];
                product.InStock = result["extension_attributes"]["stock_item"]["is_in_stock"];

                return product;
            }
            else
            {
                return null;
            }
        }
    }
}

