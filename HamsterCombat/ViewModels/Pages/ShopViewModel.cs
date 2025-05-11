using HamsterCombat.Database;
using HamsterCombat.Models;
using ReactiveUI;
using Splat;
using System.Collections.Generic;

namespace HamsterCombat.ViewModels.Pages;

public class ShopViewModel : PageBaseModel
{
    private readonly IDatabaseService? _db;
    public List<Product> Products { get; set; }

    private int _balance;
    public int Balance
    {
        get => _balance;
        set => this.RaiseAndSetIfChanged(ref _balance, value);
    }

    public ShopViewModel()
    {
        Title = "Магазин";
        _db = Locator.Current.GetService<IDatabaseService>();
        Products = _db.LoadProducts();
    }
}
