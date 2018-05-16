using System.Collections.Generic;
using MySql.Data.MySqlClient;
using LibraryManager.Controller;
using System;

namespace LibraryManager.Model {
    public class Book {
        private string title;
        private string subtitle;
        private string isbn;
        private string author;
        private string publisher;
        private string extraInformation;

        public string Subtitle { get => subtitle; set => subtitle = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string ExtraInformation { get => extraInformation; set => extraInformation = value; }
        public string Title { get => title; set => title = value; }

        public Book(string title, string subtitle, string isbn, string author, string publisher, string extraInformation) {
            Title = title;
            Subtitle = subtitle;
            Isbn = isbn;
            Author = author;
            Publisher = publisher;
            ExtraInformation = extraInformation;
        }

        public Book() {
        }

        public void Save() {
            if (DatabaseManager.Instance().IsConnect()) {
                string query = string.Format("INSERT INTO `book` (`title`, `subtitle`, `isbn`, `author`, `publisher`, `extra`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');", Title, Subtitle, Isbn, Author, Publisher, ExtraInformation);
                var cmd = new MySqlCommand(query, DatabaseManager.Instance().Connection);
                cmd.BeginExecuteNonQuery();
            }
        }

        public static List<Book> GetAll() {
            var returnList = new List<Book>();

            if (DatabaseManager.Instance().IsConnect()) {
                string query = "SELECT title FROM book";
                var cmd = new MySqlCommand(query, DatabaseManager.Instance().Connection);
                using (MySqlDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        returnList.Add(new Book(reader.GetString(0), "", "", "", "", ""));
                        string someStringFromColumnZero = reader.GetString(0);
                    }
                }
            }

            return returnList;
        }
    }
}
