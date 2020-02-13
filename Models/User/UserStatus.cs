using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI.Models.User
{
    [NotMapped]
    public class Status
    {
        public static int Active { get { return 0; } }
        public static int Blocked { get { return 1; } }
    }
}
