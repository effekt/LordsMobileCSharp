using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobile
{
    class DB
    {
        public static SQLiteConnection conn;

        public DB()
        {
            if (!System.IO.File.Exists("MaggotBot.sqlite"))
            {
                SQLiteConnection.CreateFile("MaggotBot.sqlite");
                conn = new SQLiteConnection("Data Source=MaggotBot.sqlite");
                conn.Open();
                new SQLiteCommand("CREATE TABLE accounts (account VARCHAR(15) UNIQUE NOT NULL)", conn).ExecuteNonQuery();
                new SQLiteCommand("CREATE TABLE talents (talent VARCHAR(40), level INT, account REFERENCES accounts(account))", conn).ExecuteNonQuery();
                new SQLiteCommand("CREATE TABLE buildings (building VARCHAR(40), tile INT, level INT, account REFERENCES accounts(account))", conn).ExecuteNonQuery();
            } else
            {
                conn = new SQLiteConnection("Data Source=MaggotBot.sqlite");
                conn.Open();
            }
        }

        public static SQLiteDataReader read(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, conn);
            return command.ExecuteReader();
        }

        public static void insert(string query)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(query, conn);
                command.ExecuteNonQuery();
            } catch (Exception ex)
            {

            }
        }
        
    }
}
