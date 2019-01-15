using EpiBubble.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace EpiBubble.ViewModels
{
    public class SetupViewModel : BaseViewModel
    {
        Difficulty _difficulty;
        public Difficulty SelectedDifficulty
        {
            get => _difficulty;
            set => this.RaiseAndSetIfChanged(ref _difficulty, value);
        }

        private int _countBeforeNewLine;
        public int CountBeforeNewLine
        {
            get { return _countBeforeNewLine; }
            set { this.RaiseAndSetIfChanged(ref _countBeforeNewLine , value); }
        }

        private Color _arrowColor;
        public Color ArrowColor
        {
            get { return _arrowColor; }
            set { this.RaiseAndSetIfChanged(ref _arrowColor, value); }
        }


        public override async Task Initialize()
        {
            MessageBus.Current.Listen<ContentDialogClosedEventArgs>()
                   .Subscribe(
                   x =>
                   {
                       Debug.WriteLine("Setup!!!");
                       MessageBus.Current.SendMessage(new SetupDialogClosedEventArgs()
                       {
                           NumberOfShotsBeforeNewRow = CountBeforeNewLine,
                           PreferedArrowColor = ArrowColor,
                           DifficultyLevel = SelectedDifficulty
                       });
                   },
                   e =>
                   {
                       Debug.WriteLine("Error while listening for game seting up");
                   });
            await base.Initialize();
        }
    }
}
