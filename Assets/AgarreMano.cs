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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         agarreImput = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if(agarreImput && other.CompareTag("Arma"))
        {
<<<<<<< HEAD
            child.transform.SetParent(parentSustitute);
            child.transform.localPosition = new Vector3(0,0,0);
            child.transform.localRotation = Quaternion.identity;
=======
            child.transform.SetParent(parent);
            other.transform.localPosition = new Vector3(0,0,0);
            other.transform.localRotation = Quaternion.identity;
            Debug.Log("Agarre");
>>>>>>> 3ce5a7bb0a6ce46e520cd6e771ef4e5c2b7e52d9
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerExit(Collider other)
    {
        if(agarreImput == false)
        {
            child.transform.SetParent(parentOriginal);
            child.transform.localPosition = new Vector3(0,0,0);
            child.transform.localRotation = Quaternion.identity;
        }
    }
}
