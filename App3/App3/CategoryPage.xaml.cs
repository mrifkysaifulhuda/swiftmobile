using App3.API;
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
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage(string categoryTxt)
        {
            InitializeComponent();

            RetriveItems(categoryTxt);

        }

        public async void RetriveItems(string categoryTxt)
        {
           
            List<Item> item = await GetCategory(categoryTxt);

            listItems.ItemsSource = item;           
            category.Text = categoryTxt;
        }

        public static async Task<List<Item>> GetCategory(string categoryTxt)
        {
            string queryString = "https://azdemo.getswift.asia/rest/V1/products?searchCriteria[filterGroups][0][filters][0][field]=category_id& searchCriteria[filterGroups][0][filters][0][value]=9& searchCriteria[filterGroups][0][filters][0][conditionType]=eq&searchCriteria[sortOrders][0][field]=created_at& searchCriteria[sortOrders][0][direction]=DESC& searchCriteria[pageSize]=10& searchCriteria[currentPage]=1";
            dynamic result = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            List<Item> listofItem = new List<Item>();
            if (result["items"] != null)
            {
                foreach (dynamic it in result["items"])
                {
                    Item item = new Item();
                    item.Id = it["id"];
                    item.sku = it["sku"];
                    item.name = it["name"];
                    item.price = it["price"];

                    listofItem.Add(item);
                }
                
                return listofItem;
            }
            else
            {
                return null;
            }

           
        }


        public void itemClicked(object sender, ItemTappedEventArgs e)
        {
            Item item = (Item)e.Item;
            Navigation.PushAsync(new App3.ProductDetails(item.sku));
        }
    }
    public class Item
    {
        public string Id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string price { get; set; }
    }
}