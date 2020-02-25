using System;

namespace MedalynxAPI.Models
{
    public class Environment
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int NumberOfUsers { get; set; }
        public float DataStorage { get; set; }
        public string AnalyticalApplication { get; set; } // array of id's
        public string TypeOfConnectivity { get; set; } // guid
        public RequestType Request { get; set; }
        public ObjectStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}/*  */
