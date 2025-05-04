using HamsterCombat.Models;

namespace HamsterCombat.Database;

public interface IDatabaseService
{
    int LoadPlayerInfo();
    void UpdateBalance(int balance);
    string GetDatabasePath(string name);
}
