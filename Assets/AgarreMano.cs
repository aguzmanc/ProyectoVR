using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarreMano : MonoBehaviour
{
    public bool agarreOk;
    public GameObject child;
    public Transform parentOriginal;
    public Transform parentSustitute;
        
    public bool cerca;
    public bool agarrado;
    public bool presionado;

    void Update()
    {
        presionado = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

        if(presionado && cerca && !agarrado)
        {
            agarrado = true;
            child.transform.SetParent(parentSustitute);
            child.transform.localPosition = new Vector3(0,0,0);
            child.transform.localRotation = Quaternion.identity;
            Debug.Log("Agarrado");
        }
        

        if(presionado == false && agarrado == true && cerca== true)
        {
            agarrado = false;
            child.transform.SetParent(parentOriginal);
            child.transform.localPosition = new Vector3(0,0,0);
            child.transform.localRotation = Quaternion.identity;
            // Insertar puntos
            
            child.GetComponentInChildren<ShootGun>().ResetAmmunation();
            Debug.Log("soltado");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Arma"))
        {
            cerca = true;
        }   
        
    }

    /*private void OnTriggerStay(Collider other)
    {
        if(agarreImput && other.CompareTag("Arma"))
        {
            child.transform.SetParent(parentSustitute);
            child.transform.localPosition = new Vector3(0,0,0);
            child.transform.localRotation = Quaternion.identity;
        }
    }*/
    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Arma"))
        {
            cerca = false;
        }  
    }
}
