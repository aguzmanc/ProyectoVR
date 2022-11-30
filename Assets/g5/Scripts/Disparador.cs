using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject Balas;
    public float tiempo = 0.1f;
    [Range(0, 20)]
    public float rangoRotacion = 3;
    // Start is called before the first frame update
  
    // Update is called once per frame
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
