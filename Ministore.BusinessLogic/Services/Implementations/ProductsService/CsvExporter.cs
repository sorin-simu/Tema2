using Ministore.CrossCuttingConcerns.DTOs;
using Ministore.CrossCuttingConcerns.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministore.BusinessLogic.Services.Implementations
{
    public class CsvExporter : IExporter<List<ProductDto>>
    {

        public void Export(List<ProductDto> toWrite)
        {
            using (CsvFileWriter writer = new CsvFileWriter("c:\\ListOfProducts.csv"))
            {
                foreach (var product in toWrite)
                {
                    CsvRow row = new CsvRow();
                    row.Add(String.Format("Id:{0}", product.Id));
                    row.Add(String.Format("Name:{0}", product.Name));
                    row.Add(String.Format("Price:{0}", product.Price));
                    writer.WriteRow(row);
                }

            }
        }
    }
}
