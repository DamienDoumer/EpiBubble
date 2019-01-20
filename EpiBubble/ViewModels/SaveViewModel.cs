using EpiBubble.Model.DataModel;
using EpiBubble.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiBubble.ViewModels
{
    public class SaveViewModel : ReactiveObject
    {
        string _userName;
        public string UserName
        {
            get => _userName;
            set => this.RaiseAndSetIfChanged(ref _userName, value);
        }

        public UserOptions UserOptions { get; set; }

        IDataService<UserOptions> _dataService;

        public SaveViewModel(IDataService<UserOptions> dataService)
        {
            _dataService = dataService;
        }
    }
}
