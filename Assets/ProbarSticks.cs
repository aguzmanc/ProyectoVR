using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbarSticks : MonoBehaviour
{
    public bool sirve;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger,OVRInput.Controller.RTouch))
        {
            Debug.Log("Si Entra");
            sirve = true;
        }
        else
        {
            Debug.Log("No Entra");
            sirve = false;
        }

    }
}
