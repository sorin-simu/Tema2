using System;
using Ministore.CrossCuttingConcerns.DTOs;

namespace Ministore.DataAccess.Repository.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        ProductDto GetProductById(Guid id);
        void CreateProduct(ProductDto newProduct);
        void EditProduct(ProductDto editedProduct);
        void DeleteProduct(ProductDto deletedProduct);
    }
}
