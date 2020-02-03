using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models.User
{
    [NotMapped]
    public class Credentials
    {
        public string UserEmail { get; set; } // username
        public string Password { get; set; }
    }

    [NotMapped]
    public class CredentialsInfo
    {
        public User User { get; set; }
        public Session Session { get; set; }
    }
}
