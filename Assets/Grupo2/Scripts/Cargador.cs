using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargador : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cargador")
        {
            FindObjectOfType<SpawnBalas>().CambiarCargador();
        }
    }
}
