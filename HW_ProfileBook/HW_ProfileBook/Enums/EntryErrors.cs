﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Enums
{
    public enum EntryErrors
    {
        LoginShort,
        LoginLong,
        PasswordShort,
        PasswordLong,
        PasswordЬismatch,
        LoginAlreadyTaken,
        LoginStartsWithNumbers,
        PasswordNotValid
    }
}
