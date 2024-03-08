using Microsoft.VisualBasic;
using System;

namespace ProductSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public DateTime? DeleteYMD { get; set; }

    }
}
