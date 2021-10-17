using System;

namespace SmartLock.Models
{
    public class DbModel : IDbModel
    {
        public int Id {get; set;}
        public DateTime LastUpdate {get; set;}
    }
}