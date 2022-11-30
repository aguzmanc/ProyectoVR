using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarreMano : MonoBehaviour
{
    public bool agarreOk;
    public GameObject child;
    public Transform parentOriginal;
    public Transform parentSustitute;
    bool agarreImput;
    void Update()
    {
        agarreImput = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

         if(agarreImput == false)
        {
            child.transform.SetParent(parentOriginal);
            child.transform.localPosition = new Vector3(0,0,0);
            child.transform.localRotation = Quaternion.identity;
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerStay(Collider other)
    {
        if(agarreImput && other.CompareTag("Arma"))
        {
            child.transform.SetParent(parentSustitute);
            child.transform.localPosition = new Vector3(0,0,0);
            child.transform.localRotation = Quaternion.identity;
        }
    }
    private void OnTriggerExit(Collider other)
    {
       
    }
}
