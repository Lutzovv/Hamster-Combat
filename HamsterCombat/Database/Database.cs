using Microsoft.Data.Sqlite;

namespace HamsterCombat.Database
{
    public class Database
    {
        private string db_path = "./db.sqlite";
        
        public void UpdateBalance(int balance)
        {
            string sqlExpression = $"UPDATE player_info SET balance={balance} WHERE id=0";
            using (var connection = new SqliteConnection($"Data Source={db_path}"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);

                int number = command.ExecuteNonQuery();
            }
        }
    }
}
