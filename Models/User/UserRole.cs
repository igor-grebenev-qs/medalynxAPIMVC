using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models.User
{
    [NotMapped]
    public class Role
    {
        public static string AdminUser { get { return "ADMIN"; } }
        public static string StandardUser { get { return "STANDARD_USER"; } }
    }
}
