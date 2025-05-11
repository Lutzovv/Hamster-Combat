using HamsterCombat.Models;
using System.Collections.Generic;

namespace HamsterCombat.Database;

public interface IDatabaseService
{
    void LoadPlayerInfo();
    List<Product> LoadProducts();
    void UpdateBalance(int balance);
}
