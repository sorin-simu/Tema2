using System.Collections.Generic;
using System.Linq;
using Ministore.CrossCuttingConcerns.DTOs;

namespace Ministore.DataAccess.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product model)
        {
            if (model == null) return null;
            var dto = new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price
            };
            return dto;
        }

        public static List<ProductDto> ToProductDtoList(this List<Product> listModel)
        {
            return listModel == null ? new List<ProductDto>() : listModel.Select(model => model.ToProductDto()).ToList();
        }
    }
}
