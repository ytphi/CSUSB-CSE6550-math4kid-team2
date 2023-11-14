using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class DatabaseManager : MonoBehaviour
{
    private string connectionString;
    private IDbConnection dbConnection;

    void Start()
    {
        connectionString = "URI=file:" + Application.dataPath + "/Player_details.db";

        dbConnection = new SqliteConnection(connectionString);
        //dbConnection.Open();
        Debug.Log($"Database Connection State: {dbConnection.State}");

        if (dbConnection.State != ConnectionState.Open)
        {
            dbConnection.Open();
        }

        // Create the table if it doesn't exist
        CreateTable();
        // Initialize player if not already present
        InitializePlayer();
    }


    void CreateTable()
    {
        string createTableQuery = "CREATE TABLE IF NOT EXISTS Player (ID INTEGER PRIMARY KEY AUTOINCREMENT, PlayerName TEXT, Score INTEGER)";
        ExecuteQuery(createTableQuery);
    }

    // ... (Previous code)

    void InitializePlayer()
    {
        string countQuery = "SELECT COUNT(*) FROM Player";
        IDbCommand countCommand = dbConnection.CreateCommand();
        countCommand.CommandText = countQuery;

        int playerCount = Convert.ToInt32(countCommand.ExecuteScalar());

        countCommand.Dispose();

        if (playerCount == 0)
        {
            // No player record exists, insert a new one
            string insertQuery = "INSERT INTO Player (PlayerName, Score) VALUES ('Player1', 0)";
            ExecuteQuery(insertQuery);
        }

        GetPlayer();
    }

    // ... (Other methods)

    public Player GetPlayer()
    {
        Player player = new Player();
        string selectQuery = "SELECT * FROM Player LIMIT 1";

        if (dbConnection == null)
        {
            Debug.LogError("Database connection is not initialized.");
            return player;
        }

        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = selectQuery;

        IDataReader reader = dbCommand.ExecuteReader();

        if (reader.Read())
        {
            player.ID = reader.GetInt32(0);
            player.PlayerName = reader.GetString(1);
            player.Score = reader.GetInt32(2);
            Debug.Log($"ID: {player.ID}, UserName: {player.PlayerName}, Score: {player.Score}");
        }

        reader.Close();
        dbCommand.Dispose();

        return player;
    }

    // ... (Other methods)

    void ExecuteQuery(string query)
    {
        try
        {
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            dbCommand.ExecuteNonQuery();
            dbCommand.Dispose();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception executing query: {ex.Message}");
        }
    }

    // ... (Other methods)


    public void UpdatePlayerScore(int newScore)
    {
        string updateQuery = $"UPDATE Player SET Score = {newScore} WHERE ID = 1"; // Assuming the player record has ID=1
        ExecuteQuery(updateQuery);
    }



    

    void OnDestroy()
    {
        dbConnection.Close();
    }
}

[System.Serializable]
public class Player
{
    public int ID;
    public string PlayerName;
    public int Score;
}
