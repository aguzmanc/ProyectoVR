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

    public GameObject HandInBarril;
    public GameObject HandController;

    public Transform parentGunDirection;

    void Update()
    {
        presionado = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
        //presionado = Input.GetKey(KeyCode.P);

        if(presionado && cerca && !agarrado)
        {
            agarrado = true;
            HandInBarril.SetActive(true);
            HandController.SetActive(false);
            Debug.Log("Barril Agarrado");
        }

        if(!presionado && agarrado && cerca)
        {
            agarrado = false; 
            HandInBarril.SetActive(false);  
            HandController.SetActive(true);       
            Debug.Log("Barril Soltado");
        }

        if (agarrado) {
            parentGunDirection.LookAt(transform);
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

