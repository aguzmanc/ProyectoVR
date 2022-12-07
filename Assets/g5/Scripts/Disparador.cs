using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject Balas;
    int contadorbalas;
    
    [Range(0, 20)]
    public float rangoRotacion = 3;
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            GameObject bullet =
                (GameObject)Instantiate(Balas,
                            transform.position,
                            transform.rotation);
            float rotY = Random.Range(-rangoRotacion, rangoRotacion);
            float rotX = Random.Range(-rangoRotacion, rangoRotacion);
            bullet.transform.Rotate(rotX, rotY, 0);
  
        }

    }
}
