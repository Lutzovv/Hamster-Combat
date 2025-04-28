using HamsterCombat.ViewModels.Pages;
using System.Collections.ObjectModel;
using ReactiveUI.Fody.Helpers;
using HamsterCombat.Database;

namespace HamsterCombat.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IDatabaseService _dbService;
    public ObservableCollection<PageBaseModel> PaneItems { get; set; }
    [Reactive] public PageBaseModel SelectedPageItem { get; set; }

    public MainViewModel(ref IDatabaseService dbService)
    {
        _dbService = dbService;
        PaneItems = new ObservableCollection<PageBaseModel>
        {
            new ClickerViewModel(),
            new ShopViewModel(),
            new CasinoViewModel(),
            new ProfileViewModel()
        };

        SelectedPageItem = PaneItems[0];
    }
}
