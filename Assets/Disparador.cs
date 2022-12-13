using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject _prototipo;
    public Puntos puntos;
    public float tiempo = 0.3f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempo);
            if (OVRInput.Get(OVRInput.Button.One))
            {
                _prototipo.GetComponent<FlechaVelocidad>().puntos = puntos;
                GameObject laser = (GameObject)Instantiate(_prototipo, transform.position, transform.parent.transform.rotation);  
                laser.transform.Rotate(90,90,0);  
            }      
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
