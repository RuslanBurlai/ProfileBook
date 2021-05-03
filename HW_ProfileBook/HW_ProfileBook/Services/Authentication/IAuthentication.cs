using HW_ProfileBook.Repository;

namespace HW_ProfileBook.Services.Authentication
{
    public interface IAuthentication
    {
        bool GetSameUser(string login);
        int GetUserId(string login, string password);
    }
}
