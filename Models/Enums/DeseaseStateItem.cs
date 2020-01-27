using System.ComponentModel.DataAnnotations;

namespace MedalynxAPI.Models.Enums
{
    public class DeseaseStateItem
    {
        public string Id { get; set; } // guid
        public string DeseaseState { get; set; }
        public float Percentage { get; set; }
    }
}
