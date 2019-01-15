using EpiBubble.ViewModels;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble
{
    public class AppLocator
    {
        static public SetupViewModel SetupViewModel => Locator.CurrentMutable.GetService<SetupViewModel>();
        static public SaveViewModel SaveViewModel => Locator.CurrentMutable.GetService<SaveViewModel>();
        static public GamePageViewModel GamePageViewModel => Locator.CurrentMutable.GetService<GamePageViewModel>();

        public AppLocator()
        {
            Locator.CurrentMutable.Register(() => new SetupViewModel());
            Locator.CurrentMutable.Register(() => new SaveViewModel());
            Locator.CurrentMutable.Register(() => new GamePageViewModel());
        }
    }
}
