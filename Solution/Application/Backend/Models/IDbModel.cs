using System;

namespace SmartLock.Models
{
    public interface IDbModel
    {
        long Id {get; set;}
        DateTime LastUpdate {get; set;}
    }
}