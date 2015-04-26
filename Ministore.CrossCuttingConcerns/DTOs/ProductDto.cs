using System;

namespace Ministore.CrossCuttingConcerns.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
