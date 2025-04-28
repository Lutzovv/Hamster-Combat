using HamsterCombat.Database;
using HamsterCombat.Models;
using ReactiveUI;
using Splat;
using System.Data.Common;
using System.Reactive;

namespace HamsterCombat.ViewModels.Pages;

public class ClickerViewModel : PageBaseModel
{
    private readonly IDatabaseService? _db;

    private int _balance;
    public int Balance
    {
        get => _balance;
        set => this.RaiseAndSetIfChanged(ref _balance, value);
    }

    public ReactiveCommand<Unit, Unit> ClickCommand { get; }

    public ClickerViewModel()
    {
        Title = "Кликер";
        _db = Locator.Current.GetService<IDatabaseService>();

        _balance = _db.LoadPlayerInfo();
        ClickCommand = ReactiveCommand.Create(Add);
    }

    private void Add()
    {
        Balance++;
        _db?.UpdateBalance(Balance);
    }
}
