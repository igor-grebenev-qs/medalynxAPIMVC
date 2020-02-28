using System.ComponentModel.DataAnnotations;

namespace MedalynxAPI.Models.Enums
{
    /// <summary>
    /// Environment analytical applications options (select)
    /// </summary>
    public class AnalyticalApplicationItem : BaseModelEntry
    {
        public string Id { get; set; } // guid
        public int Pos { get; set; }
        public string Name { get; set; }
    }
}
