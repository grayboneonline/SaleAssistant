using SaleAssistant.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaleAssistant.Business
{
    public interface IProductManagement
    {
        IList<SaleAssistant.Business.Models.Product> GetAllProducts();
        SaleAssistant.Business.Models.Product GetProductById(Guid productId);
        //void InsertProduct(SaleAssistant.Business.Models.Product product);
        //void DeleteProduct(Guid productId);
        //void UpdateProduct(SaleAssistant.Business.Models.Product product);
        //void Save();
    }
    public class ProductManagement
    {
        private IProductDA productDa;
        public ProductManagement(IProductDA productDa)
        {
            this.productDa = productDa;
        }

        public IList<SaleAssistant.Business.Models.Product> GetAllProducts()
        {
            return new List<SaleAssistant.Business.Models.Product>();//productDa.GetAllProducts();
        }

        public SaleAssistant.Business.Models.Product GetProductById(Guid productId)
        {
            return new SaleAssistant.Business.Models.Product();//productDa.GetProductById(productId);
        }
        //void InsertProduct(SaleAssistant.Business.Models.Product product);
        //void DeleteProduct(Guid productId);
        //void UpdateProduct(SaleAssistant.Business.Models.Product product);
        //void Save();
    }
}
