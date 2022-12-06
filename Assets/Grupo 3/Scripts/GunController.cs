using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject dart;
    public float dartSpeed =10.0f;
    private bool fired = false;
    AudioSource disparobalas;

    void Update()
    {
        if(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)> 0.9f && !fired )
        {
            disparobalas = GetComponent<AudioSource>();    
            FireDart();
            disparobalas.Play();
            fired = true;
        }
        else if(OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)> 0.5f)
        {
            fired = false;
        }
    }
    private void FireDart()
    {
        GameObject newDart = Instantiate(dart);
        newDart.GetComponent<DartController>().SetAsTemporal();
        newDart.transform.position = transform.position;
        newDart.transform.rotation = transform.rotation;
        newDart.GetComponent<Rigidbody>().velocity = newDart.transform.forward * dartSpeed;
    }
}