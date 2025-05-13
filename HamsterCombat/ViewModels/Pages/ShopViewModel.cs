using HamsterCombat.Database;
using HamsterCombat.Models;
using ReactiveUI;
using Splat;
using System.Collections.Generic;
using System.Reactive;

namespace HamsterCombat.ViewModels.Pages;

public class ShopViewModel : PageBaseModel
{
    private readonly IDatabaseService _db;
    public List<Product> Products { get; set; }
    public int Balance => _db.CurrentBalance;
    public ReactiveCommand<Product, Unit> BuyCommand { get; }

    public ShopViewModel(IDatabaseService dbService)
    {
        Title = "Магазин";
        _db = dbService;
        Products = _db.LoadProducts();

        BuyCommand = ReactiveCommand.Create<Product>(BuyProduct);

        _db.BalanceChanged += (newBalance) => this.RaisePropertyChanged(nameof(Balance));
    }

    private void BuyProduct(Product product)
    {
        float finalPrice = product.Price * product.Level * product.Ratio;

        if (_db.CurrentBalance >= finalPrice)
        {
            //_db.UpdateBalance(_db.CurrentBalance - (int)finalPrice);
            product.Level++;
            this.RaisePropertyChanged(nameof(Products));
        }
    }
}