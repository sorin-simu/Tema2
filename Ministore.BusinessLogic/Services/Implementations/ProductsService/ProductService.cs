using System;
using System.Collections;
using System.Collections.Generic;
using Ministore.BusinessLogic.Services.Interfaces;
using Ministore.CrossCuttingConcerns.DTOs;
using Ministore.DataAccess.Mappers;
using Ministore.DataAccess.UnitOfWork;
using Ninject.Infrastructure.Language;
using Ministore.CrossCuttingConcerns.Utils;

namespace Ministore.BusinessLogic.Services.Implementations.ProductsService
{
    public class ProductService : BaseService,IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public ProductDto GetProductById(Guid id)
        {
            return UnitOfWork.ProductRepository.GetProductById(id);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return UnitOfWork.ProductRepository.All().ToProductDtoList().ToEnumerable();
        }

        public void CreateProduct(ProductDto newProduct)
        {
            UnitOfWork.ProductRepository.CreateProduct(newProduct);
        }

        public void EditProduct(ProductDto editedProduct)
        {
            UnitOfWork.ProductRepository.EditProduct(editedProduct);
        }

        public void DeleteProduct(ProductDto deletedProduct)
        {
            UnitOfWork.ProductRepository.DeleteProduct(deletedProduct);
        }
    }
}
