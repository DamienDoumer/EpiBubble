using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EpiBubble.ViewModels
{
    public class GamePageViewModel : ReactiveObject
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
    }
}