using EpiBubble.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EpiBubble.Views
{
    public sealed partial class SetupDialog : ContentDialog
    {
        public SetupDialog()
        {
            DataContext = AppLocator.SetupViewModel;
            this.InitializeComponent();
            Closed += SetupDialog_Closed;
        }

        private void SetupDialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {
            MessageBus.Current.SendMessage(args);
        }
    }
}
