using System;
using MySql.Data.MySqlClient;

namespace LibraryManager.Controller {
    public class DatabaseManager {
        private DatabaseManager() {
        }

        public string Password { get; set; }

        private MySqlConnection connection = null;
        public MySqlConnection Connection {
            get { return connection; }
        }

        private static DatabaseManager _instance = null;
        public static DatabaseManager Instance() {
            if (_instance == null)
                _instance = new DatabaseManager();
            return _instance;
        }

        public bool IsConnect() {
            if (Connection == null) {
                string connstring = string.Format("Server=127.0.0.1; database=book; UID=root; password=; SslMode=none");
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }

        public void Close() {
            connection.Close();
        }
    }
}