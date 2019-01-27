using EpiBubble.Helpers;
using EpiBubble.Model.DataModel;
using EpiBubble.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EpiBubble.ViewModels
{
    public class GamePageViewModel : BaseViewModel
    {
        private string _score = 0.ToString();
        public string Score
        {
            get { return _score; }
            set { this.RaiseAndSetIfChanged(ref _score, value); }
        }
        public UserOptions UserOptions { get; set; }
        public ICommand QuitCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SetupCommand { get; private set; }
        public SetupDialogClosedEventArgs Settings { get; set; }
        SimpleNavigationService _navService;

        public GamePageViewModel(SimpleNavigationService navService)
        {
            UserOptions = new UserOptions { Score = 1, ArrowRotationAngle = 10, NumberOfBubbles = 17 };
            _navService = navService;
            QuitCommand = ReactiveCommand.Create(() => Environment.Exit(1));
            SaveCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _navService.OpenDialogAsync(DialogToNavigate.Save, UserOptions);
            });
            SetupCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await _navService.OpenDialogAsync(DialogToNavigate.Setup);
            });
            
        }

        public override async Task Initialize()
        {
            MessageBus.Current.Listen<SetupDialogClosedEventArgs>().Subscribe(arg =>
            {
                Settings = arg;
            });
        }
    }
}