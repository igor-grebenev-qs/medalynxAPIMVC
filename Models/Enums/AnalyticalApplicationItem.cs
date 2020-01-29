using System.ComponentModel.DataAnnotations;

namespace MedalynxAPI.Models.Enums
{
    /// <summary>
    /// Environment analytical applications options (select)
    /// </summary>
    public class AnalyticalApplicationItem
    {
        public string Id { get; set; } // guid
        public int Pos { get; set; }
        public string Name { get; set; }
    }
}
