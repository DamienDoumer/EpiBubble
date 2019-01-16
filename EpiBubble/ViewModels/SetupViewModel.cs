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
        public List<Difficulty> Difficulties { get; set; }

        private int _countBeforeNewLine;
        public int CountBeforeNewLine
        {
            get { return _countBeforeNewLine; }
            set { this.RaiseAndSetIfChanged(ref _countBeforeNewLine , value); }
        }

        private string _textEntered;
        public string TextEntered
        {
            get { return _textEntered; }
            set { this.RaiseAndSetIfChanged(ref _textEntered, value); }
        }


        private Color _arrowColor;
        public Color ArrowColor
        {
            get { return _arrowColor; }
            set { this.RaiseAndSetIfChanged(ref _arrowColor, value); }
        }

        public List<Color> Colors { get; set; }

        public SetupViewModel()
        {
            Colors = new List<Color>
            {
                Color.Red,
                Color.Black,
                Color.Blue,
                Color.Yellow
            };
            CountBeforeNewLine = 6;
            Difficulties = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            this.WhenAny(x => x.TextEntered, txt => txt.Value)
                .Subscribe(newText =>
                {
                    if (!string.IsNullOrEmpty(newText))
                    {
                        if (char.IsDigit(newText.Last()))
                            TextEntered = newText.Remove(TextEntered.Length - 1);
                    }
                });
        }

        public override async Task Initialize()
        {
            MessageBus.Current.Listen<ContentDialogClosedEventArgs>()
                   .Subscribe(
                   x =>
                   {
                       var isNumeric = int.TryParse(TextEntered, out int n);
                       MessageBus.Current.SendMessage(new SetupDialogClosedEventArgs()
                       {
                           NumberOfShotsBeforeNewRow = isNumeric ? n : CountBeforeNewLine,
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
