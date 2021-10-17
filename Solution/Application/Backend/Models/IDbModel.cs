using System;

namespace SmartLock.Models
{
    public interface IDbModel
    {
        int Id {get; set;}
        DateTime LastUpdate {get; set;}
    }
}