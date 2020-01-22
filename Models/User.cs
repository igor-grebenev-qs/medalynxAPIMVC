using System.ComponentModel.DataAnnotations;

namespace MedalynxAPI.Models
{
    public class User
    {
        public string Id { get; set; } // guid
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public RequestType Request { get; set; }
        public string Password { get; set; }
    }

    public enum RequestType
    {
        Created = 0,
        Approved = 1,
        Rejected = 2
    }
}
