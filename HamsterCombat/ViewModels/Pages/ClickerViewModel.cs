using ReactiveUI;
using System.Reactive;

namespace HamsterCombat.ViewModels.Pages;

public class ClickerViewModel : PageBaseModel
{
    public ReactiveCommand<Unit, Unit> ClickCommand { get; }
    private int _balance;
    public int Balance
    {
        get => _balance;
        set => this.RaiseAndSetIfChanged(ref _balance, value);
    }

    public ClickerViewModel()
    {
        Title = "Кликер";
        ClickCommand = ReactiveCommand.Create(Add);
    }

    private void Add()
    {
        Balance++;
    }
}
