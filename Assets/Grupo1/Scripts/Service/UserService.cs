using System.Net;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using UnityEngine;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnityPoyect
{
    public class UserService
    {
        private WebClient wb;
        private NameValueCollection data;

        public UserService()
        {
            wb = new WebClient();
            data = new NameValueCollection();
        }

    

        public UserSession PostUser(string user)
        {
            string param = "{\"name_user\":\"" + user + "\"}";
            wb.Headers.Add("content-type", "application/json");
            byte[]e =  wb.UploadData(ConnectionDB.requestUriMain+"users", "POST", Encoding.UTF8.GetBytes(param));
            string response =  Encoding.ASCII.GetString(e);
           
            return JsonUtility.FromJson<UserSession>(response);
        }
        
    }
}