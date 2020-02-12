using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models.User
{
    [NotMapped]
    public class UserRepresentation : User
    {
        public UserRepresentation(User user) {
            Utils.CopyPropertyValues<User>(user, this);
        }

        public CredentialsInfo CredentialsInfo { get; set; }
    }
}
