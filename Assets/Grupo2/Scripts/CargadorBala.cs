using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorBala : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cargador")
        {
            FindObjectOfType<SpawnBalas>().CargarBalas();
        }
    }
}
