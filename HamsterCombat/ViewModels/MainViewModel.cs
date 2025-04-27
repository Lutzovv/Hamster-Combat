using HamsterCombat.ViewModels.Pages;
using System.Collections.ObjectModel;
using ReactiveUI.Fody.Helpers;

namespace HamsterCombat.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<PageBaseModel> PaneItems { get; set; }
    [Reactive] public PageBaseModel SelectedPageItem { get; set; }

    public MainViewModel()
    {
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
