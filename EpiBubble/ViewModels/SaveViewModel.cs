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
    public class SaveViewModel : BaseViewModel
    {
        string _userName;
        public string UserName
        {
            get => _userName;
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }

        public UserOptions UserOptions { get; set; }

        IDataService<UserOptions> _dataService;

        public ICommand CloseCommand { get; private set; }

        public SaveViewModel(IDataService<UserOptions> dataService)
        {
            _dataService = dataService;
            CloseCommand = ReactiveCommand.Create(() =>
            {
                UserOptions.UserName = UserName;
                dataService.Save(UserOptions);
            });
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }
    }
}