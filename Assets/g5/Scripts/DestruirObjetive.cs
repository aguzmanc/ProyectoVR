using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetive : MonoBehaviour
{
    bool sumaPuntos;
    // Start is called before the first frame update
    void Start()
    {
        sumaPuntos = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Objetive" && sumaPuntos){
            sumaPuntos = false;
            FindObjectOfType<Controlador>().SumarPuntos(10);
            Destroy( other.gameObject);
        }
    }
}
