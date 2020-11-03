using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Dochazka.Utils {
    public class DatabaseHandler {
        private static string DBPATH;
        private static string DBNAME = "dochazka.db";

        /// <summary>
        /// Use this only once when starting application.
        /// </summary>
        /// <returns>True if database was established. False in other cases.</returns>
        public static bool Init() {
            DBPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Dochazka");

            if (!Directory.Exists(DBPATH)) {
                Directory.CreateDirectory(DBPATH);
            }

            if (!File.Exists(Path.Combine(DBPATH, DBNAME))) {
                SQLiteConnection.CreateFile(Path.Combine(DBPATH, DBNAME));
            }

            Console.WriteLine(DBPATH);
            if (!PrepareDBTables()) return false;

            return true;
        }

        private static bool PrepareDBTables() {
            return CheckTable("STUDENTS");
        }

        private static bool CheckTable(string name) {
            string query = "SELECT * FROM " + name + ";";
            SQLiteConnection conn = null;
            SQLiteCommand command = null;
            try {
                conn = CreateConnection();
                conn.Open();
                command = new SQLiteCommand(query, conn);
                SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly);
                command.Dispose();
                conn.Close();
                reader.Dispose();
                return true;
            }
            catch (Exception e) {
                if (e.Message.Contains("no table")) {
                    CreateTable(
                        "CREATE TABLE STUDENTS (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, TEXT NAME NOT NULL );");
                    return true;
                }
                else {
                    Console.WriteLine(e);
                    return false;
                }
            }
            finally {
                if (conn != null)
                    conn.Close();
                if (command != null)
                    command.Dispose();
            }
        }

        private static void CreateTable(string query) {
            SQLiteConnection conn = CreateConnection();
            SQLiteCommand command = new SQLiteCommand(query, conn);
            conn.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            conn.Close();
        }

        public static SQLiteConnection CreateConnection() {
            string connString = string.Format("Data Source={0};Version=3;", Path.Combine(DBPATH, DBNAME));
            return new SQLiteConnection(connString);
        }
    }
}