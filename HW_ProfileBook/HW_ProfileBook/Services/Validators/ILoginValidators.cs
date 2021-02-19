using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Services.Validators
{
    public interface ILoginValidators
    {
        bool LoginValid(string login);
    }
}
