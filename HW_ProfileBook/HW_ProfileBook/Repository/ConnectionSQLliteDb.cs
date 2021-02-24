using SQLite;
using System;
using System.IO;

namespace HW_ProfileBook.Repository
{
    public class ConnectionSQLliteDb : IConnectionSQLiteDb
    {
        public SQLiteConnection GetProfileConnection()
        {
            var dataBaseName = "Profiles.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, dataBaseName);
            return new SQLiteConnection(path);

        }

        public SQLiteConnection GetUserConnection()
        {
            var dataBaseName = "Users.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, dataBaseName);
            return new SQLiteConnection(path);
        }
    }
}
