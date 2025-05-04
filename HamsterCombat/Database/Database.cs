using Microsoft.Data.Sqlite;
using System;
using System.Data.Common;
using System.IO;

namespace HamsterCombat.Database;

public class DatabaseService : IDatabaseService
{
    private string? db_path;

    public DatabaseService()
    {
        db_path = GetDatabasePath("db.sqlite");
        CreateDB();
    }


    private void CreateDB()
    {
        using (var connection = new SqliteConnection($"Data Source={db_path}"))
        {
            connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS player_info (
                    id INTEGER,
                    name TEXT,
                    balance INTEGER)";
            command.ExecuteNonQuery();

            command.CommandText = "SELECT * FROM player_info WHERE id = 0";
            if (command.ExecuteScalar() == null )
            {
                command.CommandText = "INSERT INTO player_info (id, name, balance) VALUES (0, 'user', 0)";
                command.ExecuteNonQuery();
            }
        }

        //using var connection = new SqliteConnection($"Data Source={db_path}");
        //connection.Open();
        //string sql = @"
        //    CREATE TABLE IF NOT EXISTS player_info (
        //        id integer,
        //        name TEXT,
        //        balance INTEGER";
        //var createDB = new SqliteCommand( sql, connection );

        //sql = "SELECT * FROM player_info WHERE id = 0";

        //using var command = new SqliteCommand( sql, connection );
        //if (command.ExecuteScalar() == null)
        //{
        //    sql = "INSERT INTO player_info "
        //}
    }


    public int LoadPlayerInfo()
    {
        using var connection = new SqliteConnection($"Data Source={db_path}");
        connection.Open();

        const string sql = "SELECT balance FROM player_info WHERE id = 0";
        using var command = new SqliteCommand(sql, connection);

        return Convert.ToInt32(command.ExecuteScalar() ?? 0);
    }

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


    public string GetDatabasePath(string name)
    {
        //if (OperatingSystem.IsAndroid())
        //{
        //    string personalPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        //    string databaseDir = Path.Combine(personalPath, "Database");
        //    //if (!Directory.Exists(databaseDir))
        //    //{
        //    //    Directory.CreateDirectory(databaseDir);
        //    //}

        //    return Path.Combine(databaseDir, name);
        //}
        
        //string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //string appDir = Path.Combine(appDataPath, "HamsterCombat");
        //if (!Directory.Exists(appDir))
        //{
        //    Directory.CreateDirectory(appDir);
        //}
        //return Path.Combine(appDir, name);

        //string appPath = Environment.SpecialFolder.LocalApplicationData.ToString();
        var dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), name);
        return dbPath;
    }
}
