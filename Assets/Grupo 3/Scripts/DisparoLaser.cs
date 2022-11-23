using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoLaser : MonoBehaviour
{
    public float velocidad = 10;
    //public float tiempo = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,1);
        //WaitForSeconds waitForSeconds = new WaitForSeconds();
        //Destroy(gameObject, 3.0f);
    }
}
