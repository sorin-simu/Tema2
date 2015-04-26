using System;
using System.Collections.Generic;
using Ministore.CrossCuttingConcerns.DTOs;

namespace Ministore.BusinessLogic.Services.Interfaces
{
    public interface IProductService
    {
        ProductDto GetProductById(Guid id);
        IEnumerable<ProductDto> GetAll();
        void CreateProduct(ProductDto newProduct);
        void EditProduct(ProductDto editedProduct);
        void DeleteProduct(ProductDto deletedProduct);
    }
}
