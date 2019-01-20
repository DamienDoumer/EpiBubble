using EpiBubble.Model.DataModel;
using EpiBubble.Services;
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
        static public IDataService<UserOptions> DataService => Locator.CurrentMutable.GetService<IDataService<UserOptions>>();

        public AppLocator()
        {
            Locator.CurrentMutable.Register<IDataService<UserOptions>>(() => new UserOptionsDataService());
            Locator.CurrentMutable.Register(() => new SimpleNavigationService());
            Locator.CurrentMutable.Register(() => new SetupViewModel());
            Locator.CurrentMutable.Register(() => new SaveViewModel(DataService));
            Locator.CurrentMutable.Register(() => new GamePageViewModel(Locator.CurrentMutable.GetService<SimpleNavigationService>()));
        }
    }
}
