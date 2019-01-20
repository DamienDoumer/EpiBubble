using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.Services
{
    public interface IDataService<T>
    {
        T Read();
        bool Delete();
        bool Update(T item);
        bool Save(T item);
    }
}
