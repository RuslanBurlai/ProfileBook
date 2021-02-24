using SQLite;

namespace HW_ProfileBook.Repository
{
    public interface IConnectionSQLiteDb
    {
        SQLiteConnection GetUserConnection();
        SQLiteConnection GetProfileConnection();
    }
}
