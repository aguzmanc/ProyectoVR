using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBarrilWithLeft : MonoBehaviour
{    
    public bool cerca;
    public bool agarrado;
    public bool presionado; 

    public Transform parentOriginal;
    public Transform parentSustitute;   
    
    void Update()
    {
        presionado = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);

        if(presionado && cerca && !agarrado)
        {
            agarrado = true;
            transform.SetParent(parentSustitute);
            transform.localPosition = new Vector3(0,0,0);
            transform.localRotation = Quaternion.identity;
            Debug.Log("Barril Agarrado");
        }

        if(!presionado && agarrado && cerca)
        {
            agarrado = false;
            transform.SetParent(parentOriginal);
            transform.localPosition = new Vector3(0,0,0);
            transform.localRotation = Quaternion.identity;            
            Debug.Log("Barril Soltado");
        }

        if (presionado && agarrado && cerca) {
            transform.localPosition = new Vector3(0,0,0);
            transform.localRotation = Quaternion.identity;            
        } 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Barril"))
        {
            cerca = true;
        }   
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Barril"))
        {
            cerca = false;
        }  
    }

}

