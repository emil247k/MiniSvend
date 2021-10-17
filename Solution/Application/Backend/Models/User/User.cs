using System;
using SmartLock.Models;

namespace SmartLock.Models.User
{
    public class User : DbModel
    {
        public string Name {get; set; }
        public string LastName {get; set; }
        public string Email {get; set; }
        public string Username {get; set; }
        public string ShaID {get; set; }
        public DateTime LastLogin{get; set;}
    }
}