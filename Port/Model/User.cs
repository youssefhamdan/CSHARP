using System;

namespace Port.Model
{
    internal class User
    {
        public String username { get; set; }
        public int idAcces { get; set; }

        public User()
        {
        }

        public User(String username, int idAcces)
        {
            this.username = username;
            this.idAcces = idAcces;
        }
    }
}