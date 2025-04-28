using HamsterCombat.Models;
using ReactiveUI;
using System.Data.Common;
using System.Reactive;

namespace HamsterCombat.ViewModels.Pages;

public class ClickerViewModel : PageBaseModel
{
    private readonly Player _player = new Player();

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

        // Инициализируем баланс из Player
        _balance = _player.Balance_;

        ClickCommand = ReactiveCommand.Create(Add);
    }

    private void Add()
    {
        Balance++;
        _player.Balance_ = Balance;
    }
}
