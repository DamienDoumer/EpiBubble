using EpiBubble.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EpiBubble.Services
{
    public class SimpleNavigationService
    {
        public async Task OpenDialogAsync()
        {
            SetupDialog setupDialog = new SetupDialog();
            await setupDialog.ShowAsync();
        }
    }
}
