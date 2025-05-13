using HamsterCombat.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Xml.Linq;

namespace HamsterCombat.Database;

public class DatabaseService : IDatabaseService
{
    private string? db_path;
    private int _currentBalance;

    public int CurrentBalance => _currentBalance;
    public event Action<int>? BalanceChanged;

    public DatabaseService()
    {
        db_path = GetDatabasePath("db.sqlite");
        CreateDB();
        LoadPlayerInfo();
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
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS products (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT,
                    price REAL,
                    ratio REAL,
                    imageURL TEXT,
                    level INTEGER
                )";
            command.ExecuteNonQuery();


            command.CommandText = "SELECT * FROM player_info WHERE id = 0";
            if (command.ExecuteScalar() == null )
            {
                command.CommandText = "INSERT INTO player_info (id, name, balance) VALUES (0, 'user', 0)";
                command.ExecuteNonQuery();
            }
        }
    }


    public void LoadPlayerInfo()
    {
        using var connection = new SqliteConnection($"Data Source={db_path}");
        connection.Open();

        const string sql = "SELECT * FROM player_info WHERE id = 0";
        using var command = new SqliteCommand(sql, connection);
        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            _currentBalance = reader.GetInt32(2);
            BalanceChanged?.Invoke(_currentBalance);
        }
    }


    public List<Product> LoadProducts()
    {
        List<Product> products = new List<Product>();

        using var connection = new SqliteConnection($"Data Source={db_path}");
        connection.Open();

        const string sql = "SELECT * FROM products";
        var command = new SqliteCommand(sql, connection);

        using ( var reader = command.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    float price = reader.GetFloat(2);
                    float ratio = reader.GetFloat(3);
                    string imageURL = "D:\\code\\projects\\cs\\Avalonia\\HamsterCombat\\HamsterCombat\\Assets\\" + reader.GetString(4);
                    int level = reader.GetInt32(5);

                    products.Add(new Product(id, name, price, ratio, imageURL, level));
                }
            }
        }

        return products;
    }


    public void UpdateBalance(int balance)
    {
        _currentBalance = balance;

        string sqlExpression = $"UPDATE player_info SET balance={balance} WHERE id=0";
        using (var connection = new SqliteConnection($"Data Source={db_path}"))
        {
            connection.Open();

            SqliteCommand command = new SqliteCommand(sqlExpression, connection);

            int number = command.ExecuteNonQuery();
        }

        BalanceChanged?.Invoke(balance);
    }


    private string GetDatabasePath(string name)
    {
        var dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), name);
        return dbPath;
    }
}
