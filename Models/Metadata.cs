using System;

namespace MedalynxAPI.Models
{
    public class Metadata : BaseModelEntry
    {
        public string Id { get; set; }
        public int MetadataOrder { get; set; }
        public string Comment { get; set; }
        public string Data { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
