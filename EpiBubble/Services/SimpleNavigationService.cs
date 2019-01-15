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
    public enum DialogToNavigate
    {
        Setup,
        Save
    }

    public class SimpleNavigationService
    {
        public async Task OpenDialogAsync(DialogToNavigate dialogToNavigate)
        {
            if (dialogToNavigate == DialogToNavigate.Setup)
            {
                await AppLocator.SetupViewModel.Initialize();
                SetupDialog setupDialog = new SetupDialog();
                setupDialog.DataContext = AppLocator.SetupViewModel;
                await setupDialog.ShowAsync();
            }
            else
            {

            }
        }
    }
}
