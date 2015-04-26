using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Ministore.CrossCuttingConcerns.DTOs;
using Ministore.DataAccess.Mappers;
using Ministore.DataAccess.Repository.Interfaces;

namespace Ministore.DataAccess.Repository.Implementations
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IObjectContextAdapter dbContext) : base(dbContext)
        {
        }

        public ProductDto GetProductById(Guid id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id).ToProductDto();
        }

        public void CreateProduct(ProductDto newProduct)
        {
            var product = new Product
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                Price = newProduct.Price
            };
            Add(product);
        }

        public void EditProduct(ProductDto editedProduct)
        {
            var product = new Product
            {
                Id = editedProduct.Id,
                Name = editedProduct.Name,
                Price = editedProduct.Price
            };
            Edit(product);
        }

        public void DeleteProduct(ProductDto deletedProduct)
        {
            var product = new Product
            {
                Id = deletedProduct.Id,
                Name = deletedProduct.Name,
                Price = deletedProduct.Price
            };
            Delete(product);
        }
    }
}
