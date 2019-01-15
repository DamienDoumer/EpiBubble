using EpiBubble.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace EpiBubble.ViewModels
{
    public class SetupViewModel : BaseViewModel
    {
        public override async Task Initialize()
        {
            MessageBus.Current.Listen<ContentDialogClosedEventArgs>()
                   .Subscribe(
                   x =>
                   {
                       Debug.WriteLine("Setup!!!");
                       MessageBus.Current.SendMessage(new SetupDialogClosedEventArgs() { });
                   },
                   e =>
                   {
                       Debug.WriteLine("Error while listening for game seting up");
                   });
            await base.Initialize();
        }
    }
}
