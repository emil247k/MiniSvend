using System;

namespace SmartLock.Models
{
    public class DbModel : IDbModel
    {
        public long Id {get; set;}
        public DateTime LastUpdate {get; set;}
    }
}