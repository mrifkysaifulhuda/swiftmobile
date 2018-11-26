using App3.Model;
using App3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetails : ContentPage
	{
        IProductService productService = new ProductService();
        public ProductDetails (string sku)
		{
			InitializeComponent ();
            retriveData(sku);

        }

        private async void retriveData(string sku)
        {
            Product product = await productService.GetProductDetails(sku);
            name.Text = product.Name;
            price.Text = "$" + product.Price;
            if (product.InStock)
            {
                inStock.Text = "IN STOCK";
            }
            else
            {
                inStock.Text = "OUT OF STOCK";
            }
        }
	}
}