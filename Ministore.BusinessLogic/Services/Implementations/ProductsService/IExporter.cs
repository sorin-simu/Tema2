using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ministore.BusinessLogic.Services.Implementations
{
    public interface IExporter<T>
    {
        void Export(T toWrite);
    }
}
