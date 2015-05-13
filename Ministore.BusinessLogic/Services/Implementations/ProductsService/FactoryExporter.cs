using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministore.BusinessLogic.Services.Implementations.ProductService
{
    public class FactoryExporter<T> where T: new()
    {
        public T CreateExporter()
        {
            return new T();
        }
    }
}
