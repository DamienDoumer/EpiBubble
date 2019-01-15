using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject
    {
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }

        public virtual Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}
