using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.ViewModels
{
    public interface IViewModel
    {
        Task Initialize();
        Task Stop();
    }
}
