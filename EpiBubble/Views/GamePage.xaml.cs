using EpiBubble.Helpers;
using EpiBubble.Views;
using Microsoft.Xna.Framework;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EpiBubble
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
		readonly Game _game;

		public GamePage()
        {
            this.InitializeComponent();

            var launchArguments = string.Empty;
            // Create the game.
            if (DeviceDetector.DetectDeviceType() == DeviceType.Desktop)
            {
                _game = MonoGame.Framework.XamlGame<EpiBubbleDesktopGame>.Create(launchArguments, Window.Current.CoreWindow, swapChainPanel);
            }
            else if(DeviceDetector.DetectDeviceType() == DeviceType.Tablet)
            {
                _game = MonoGame.Framework.XamlGame<EpiBubbleDesktopGame>.Create(launchArguments, Window.Current.CoreWindow, swapChainPanel);
            }
            else if (DeviceDetector.DetectDeviceType() == DeviceType.XBOX)
            {
                _game = MonoGame.Framework.XamlGame<EpiBubbleXboxGame>.Create(launchArguments, Window.Current.CoreWindow, swapChainPanel);
            }
        }
    }
}
