using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.Services
{
    public interface IDataService<T>
    {
        Task<T> Read();
        Task<bool> Delete();
        Task<bool> Update(T item);
        Task<bool> Save(T item);
    }
}
