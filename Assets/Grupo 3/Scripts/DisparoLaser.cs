using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoLaser : MonoBehaviour
{
    public float velocidad = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,1);
    }
}
