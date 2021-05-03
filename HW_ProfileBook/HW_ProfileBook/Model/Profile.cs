using HW_ProfileBook.Repository;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW_ProfileBook.Model
{
    [Table("Profiles")]
    public class Profile : IEntityBaseForModel
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        public string ProfileImage { get; set; }
        public string NickNameLabel { get; set; }
        public string NameLabel { get; set; }
        public DateTime DateLabel { get; set; }
        [MaxLength(120)]
        public string Description { get; set; }

        public int UserId { get; set; }
    }

}
