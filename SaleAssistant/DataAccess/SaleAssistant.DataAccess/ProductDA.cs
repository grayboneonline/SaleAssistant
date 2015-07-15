using SaleAssistant.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SaleAssistant.DataAccess
{
    public interface IProductDA
    {
        IList<Product> GetAllProducts();
        Product GetProductById(Guid productId);
        void InsertProduct(Product product);
        void DeleteProduct(Guid productId);
        void UpdateProduct(Product product);
        void Save();
    }

    public class ProductDA : IProductDA
    {
        private SaleAssistantDbContext dbContext;

        public ProductDA(SaleAssistantDbContext context) 
        {
            dbContext = context;
        }

        public IList<Product> GetAllProducts()
        {
            return dbContext.Products.ToList();
        }

        public Product GetProductById(Guid productId)
        {
            return dbContext.Products.Find(productId);
        }

        public void InsertProduct(Product product)
        {
            dbContext.Products.Add(product);
        }

        public void DeleteProduct(Guid productID)
        {
            Product product = dbContext.Products.Find(productID);
            dbContext.Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            dbContext.Entry(product).State = EntityState.Modified;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
