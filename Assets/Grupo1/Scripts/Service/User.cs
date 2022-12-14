using UnityEngine;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace UnityPoyect
{
    
    public class User
    {

        public User()
        {
            
        }
        public int _idUser;
        public int idUser
        {
            get { return _idUser; }
            set { _idUser = value; }
        }
        
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string createAt;
        public string CreateAt
        {
            get { return createAt; }
            set { createAt = value; }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        
        


        
        
    }

    public class UserSession{
        public int idUser;
    }
}
