using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject _prototipo;
    public Puntos puntos;
    public float tiempo = 0.3f;
    public AudioSource As;
    public AudioClip Ac;

    IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.Space) /*OVRInput.Get(OVRInput.Button.One)*/)
            {
                _prototipo.GetComponent<FlechaVelocidad>().puntos = puntos;
                GameObject laser = (GameObject)Instantiate(_prototipo, transform.position, transform.parent.transform.rotation);  
                laser.transform.Rotate(90,90,0);  
                As.PlayOneShot(Ac);
            }   
            yield return new WaitForSeconds(tiempo);   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
