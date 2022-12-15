using UnityEngine;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace UnityPoyect
{
    public class UserList
    {
        public User [] users;
    }
    
    public class User
    {
        public User()
        {
            
        }
        public int idUser;
        private string nameUser;
        private string create_at;
        private int status;

        
        


        
        
    }

    public class UserSession{
        public int idUser;
    }
}
