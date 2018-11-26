using App3.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App3.Service
{
    public interface IProductService
    {
        Task<Product> GetProductDetails(string sku);
    }
}
