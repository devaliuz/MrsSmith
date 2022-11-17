using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MrSmith
{
    internal class Commands
    {
        public Commands() 
        {
            if (!File.Exists("./Commands.sqlite3"))
            {
                SQLiteConnection.CreateFile("Commands.sqlite3");
                using (SQLiteConnection connection = new SQLiteConnection("Data Source = Commands.sqlite3"))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE 'Idle'('Command' TEXT NOT NULL, 'Response' TEXT NOT NULL)", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE 'Commands'('Command' TEXT NOT NULL, 'Response' TEXT NOT NULL)", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public int count(string table)
        {
            int entries = 0;
            try
            {
                using (SQLiteConnection c = new SQLiteConnection("Data Source = Commands.sqlite3"))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM "+table, c))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    entries++;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return entries;
        }

        public string[] getCommands(string table) 
        {
            int entries = count(table);
            string[] commands = new string[entries];
            {
                try 
                {
                    int index = 0;
                    using(SQLiteConnection c = new SQLiteConnection("Data Source = Commands.sqlite3")) 
                    {
                        c.Open();
                        using(SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM "+table,c)) 
                        {
                            using(SQLiteDataReader rd = cmd.ExecuteReader()) 
                            {
                                while (rd.Read()) 
                                {
                                    commands[index] = rd["Command"].ToString();
                                    index++;
                                }
                            }
                        }
                    }
                }
                catch(Exception e) 
                {
                    MessageBox.Show(e.Message);
                }
                return commands;
            }
        }

        public string feedback(string table, string command) 
        {
            try
            {
                using (SQLiteConnection c = new SQLiteConnection("Data Source = Commands.sqlite3"))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("SELECT Response FROM " + table + " WHERE Command=" + "'"+command+"'", c))
                    {
                        using (SQLiteDataReader rd = cmd.ExecuteReader())
                        {
                            rd.Read();
                            return rd["Response"].ToString();                            
                        }
                    }
                }
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message);
                return "";
            }
        }
        public void actualizeTime() 
        {
            try 
            {
                DateTime tm = DateTime.Now;
                string time = "Es ist gerade " + tm.ToString("hh") + " Uhr "+tm.ToString("mm")+"!";
                string day = "Heute ist " +tm.ToString("dddd")+" der "+tm.ToString("dd")+". "+tm.ToString("MMMM")+"!";
                using (SQLiteConnection c = new SQLiteConnection("Data Source = Commands.sqlite3")) 
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Commands SET Response =" + "'" + time + "'" + "WHERE Command ='Wie spät ist es?'",c)) 
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SQLiteCommand cmd = new SQLiteCommand("UPDATE Commands SET Response =" + "'" + day + "'" + "WHERE Command ='Welcher Tag ist heute?'", c))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception e) 
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
