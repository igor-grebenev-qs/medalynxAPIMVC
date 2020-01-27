using System.ComponentModel.DataAnnotations;

namespace MedalynxAPI.Models.Enums
{
    public class AnalyticalApplicationItem
    {
        public string Id { get; set; } // guid
        public int Pos { get; set; }
        public string Name { get; set; }
    }
}
