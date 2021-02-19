using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Model
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
