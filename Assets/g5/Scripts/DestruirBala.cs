using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBala : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Balas" )
        {
            
            Debug.Log("Eliminado");
        }
    }
}
