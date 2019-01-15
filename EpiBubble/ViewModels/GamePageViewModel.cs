using EpiBubble.Helpers;
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

        public ICommand QuitCommand { get; private set; }
        public ICommand RestartCommand { get; private set; }
        public ICommand SetupCommand { get; private set; }
        public SetupDialogClosedEventArgs Settings { get; set; }
        SimpleNavigationService _navService;

        public GamePageViewModel(SimpleNavigationService navService)
        {
            _navService = navService;
            QuitCommand = ReactiveCommand.Create(() => Environment.Exit(1));
            RestartCommand = ReactiveCommand.Create(() =>
            {
                MessageBus.Current.SendMessage(new RestartEventArgs { Sender = this });
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