using System;

namespace MedalynxAPI.Models
{
    public class Enviroment
    {
        public string Id { get; set; } // guid
        public string UserId { get; set; } // user
        public int NumberOfUsers { get; set; }
        public float DataStorage { get; set; }
        public string AnalyticalApplication { get; set; } // array of id's
        public string TypeOfConnectivity { get; set; } // guid
        public RequestType Request { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
