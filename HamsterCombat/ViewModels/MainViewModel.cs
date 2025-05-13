using HamsterCombat.ViewModels.Pages;
using System.Collections.ObjectModel;
using ReactiveUI.Fody.Helpers;
using HamsterCombat.Database;
using HamsterCombat.Models;
using ReactiveUI;

namespace HamsterCombat.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IDatabaseService _dbService;

    public ObservableCollection<PageBaseModel> PaneItems { get; set; }
    [Reactive] public PageBaseModel SelectedPageItem { get; set; }

    public MainViewModel(IDatabaseService dbService)
    {
        _dbService = dbService;
        PaneItems = new ObservableCollection<PageBaseModel>
        {
            new ClickerViewModel(_dbService),
            new ShopViewModel(_dbService),
            //new CasinoViewModel(),
            //new ProfileViewModel()
        };

        SelectedPageItem = PaneItems[0];
    }
}
