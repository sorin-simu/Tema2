using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministore.BusinessLogic.Services.Implementations
{
    public class JsonExporter : IExporter<string>
    {

        public void Export(string toWrite)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\ListOfProducts.txt");
            file.WriteLine(toWrite);
            file.Close();
        }
    }
}
