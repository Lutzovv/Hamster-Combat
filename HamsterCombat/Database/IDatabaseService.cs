using HamsterCombat.Models;
using System;
using System.Collections.Generic;

namespace HamsterCombat.Database;

public interface IDatabaseService
{
    int CurrentBalance { get; }

    void LoadPlayerInfo();
    List<Product> LoadProducts();
    void UpdateBalance(int balance);
    event Action<int> BalanceChanged;
}
