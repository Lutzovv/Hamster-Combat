using HamsterCombat.Database;
using HamsterCombat.Models;
using ReactiveUI;
using Splat;
using System;
using System.Reactive;

namespace HamsterCombat.ViewModels.Pages;

public class ClickerViewModel : PageBaseModel
{
    private readonly IDatabaseService? _db;

    public int Balance => _db.CurrentBalance;

    public ReactiveCommand<Unit, Unit> ClickCommand { get; }

    public ClickerViewModel(IDatabaseService dbService)
    {
        Title = "Кликер";
        _db = dbService;
        ClickCommand = ReactiveCommand.Create(Add);

        _db.BalanceChanged += newBalance => this.RaisePropertyChanged(nameof(Balance));
    }

    private void Add()
    {
        if (_db != null)
        {
            _db.UpdateBalance(_db.CurrentBalance + 1);
        }
    }

}
