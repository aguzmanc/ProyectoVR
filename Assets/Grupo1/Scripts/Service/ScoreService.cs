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
    public class ScoreService
    {
        private WebClient wb;
        private NameValueCollection data;        

        public ScoreService()
        {
            wb = new WebClient();
            data = new NameValueCollection();
        }

        public void PostScore(int idUser, double score)
        {
            try
            {
<<<<<<< HEAD
                string param = "{\"user_iduser\":\"" + user + "\", \"score\": "+  score+" }";
                Debug.Log(param);
                wb.Headers.Add("content-type", "application/json");
                byte[]e =  wb.UploadData(ConnectionDB.requestUriMain+"users", "POST", Encoding.UTF8.GetBytes(param));
=======
                string param = "{\"user_iduser\":" + idUser + ", \"score\": "+  score+" }";
                Debug.Log(param);
                wb.Headers.Add("content-type", "application/json");
                byte[]e =  wb.UploadData(ConnectionDB.requestUriMain+"score", "POST", Encoding.UTF8.GetBytes(param));
>>>>>>> e8daa1aa855addc0845fd3390f9823cd868a248d
                string response =  Encoding.ASCII.GetString(e);
                Debug.Log(response);
            
<<<<<<< HEAD
                return JsonUtility.FromJson<UserSession>(response);
=======
                //return JsonUtility.FromJson<UserSession>(response);
>>>>>>> e8daa1aa855addc0845fd3390f9823cd868a248d
            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        
    }
}