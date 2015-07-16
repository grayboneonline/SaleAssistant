using AutoMapper;
using SaleAssistant.Business.Models;
using SaleAssistant.DataAccess;
using System;
using System.Collections.Generic;

namespace SaleAssistant.Business
{
    public interface IProductManagement
    {
        IList<Product> GetAllProducts();
        Product GetProductById(Guid productId);
        void InsertProduct(Product product);
        void DeleteProduct(Guid productId);
        void UpdateProduct(Product product);
        void Save();
    }
    public class ProductManagement : IProductManagement
    {
        private readonly IProductDA productDa;
        public ProductManagement(IProductDA productDa)
        {
            this.productDa = productDa;
        }

        public IList<Product> GetAllProducts()
        {
            return Mapper.Map<IList<Product>>(productDa.GetAllProducts());
        }

        public Product GetProductById(Guid productId)
        {
            return Mapper.Map<Product>(productDa.GetProductById(productId));
        }

        public void InsertProduct(Product product)
        {
            productDa.InsertProduct(Mapper.Map<Data.Entities.Product>(product));
        }

        public void DeleteProduct(Guid productId)
        {
            productDa.DeleteProduct(productId);
        }

        public void UpdateProduct(Product product)
        {
            productDa.UpdateProduct(Mapper.Map<Data.Entities.Product>(product));
        }

        public void Save()
        {
            productDa.Save();
        }
    }
}
