using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public class SpawnBalas : MonoBehaviour
{
    [SerializeField]
    private GameObject bala;
    [SerializeField]
    int segundosControlDisparo;
    [SerializeField]
    bool controladorCorrutina = true;
    [SerializeField]
    bool botonDisparo;
    bool controladorDisparo;
    void Start()
    {
        controladorDisparo = true;
    }
    void Update()
    {
        /*if ((OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0) && (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.RTouch) > 0))
        {
            botonDisparo = true;
        }
        else
        {
            botonDisparo = false;
        }*/
        botonDisparo = true;
        /*else botonDisparo = false;*/
        if (botonDisparo)
            if (controladorCorrutina)
            {
                StartCoroutine(Coroutine(segundosControlDisparo));
            }
    }
    IEnumerator Coroutine(int segundos)
    {
        if (controladorDisparo && botonDisparo) Instantiate(bala, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), transform.rotation);
        controladorCorrutina = false;
        controladorDisparo = false;
        yield return new WaitForSeconds(segundos);
        controladorDisparo = true;
        controladorCorrutina = true;
    }
}
