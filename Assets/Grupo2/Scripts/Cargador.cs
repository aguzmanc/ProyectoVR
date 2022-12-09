using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargador : MonoBehaviour
{
    [SerializeField]
    private GameObject cargadorVacio;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cargador")
        {
            Destroy(other.gameObject);
            if(FindObjectOfType<SpawnBalas>().CargadorEnArma()) Instantiate(cargadorVacio, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            FindObjectOfType<SpawnBalas>().CambiarCargador();
        }
    }
}
