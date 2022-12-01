using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBoton : MonoBehaviour
{
    BotonVR boton;
    private void Start() {

        boton = GetComponentInParent<BotonVR>();

    }
    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Mano")
        {
            boton.Presionar();
        }           
        
    }
    private void OnTriggerExit(Collider other) {

        if(other.tag == "Mano")
        {
            boton.Soltar();
        }

    }
    private void OnTriggerStay(Collider other) {

        if(other.tag == "Mano")
        {
            boton.Presionar();
        }
    }
}
