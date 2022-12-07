using Oculus.Platform.Samples.VrBoardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject Balas;
    private int municionRifle = 30;
    public GameObject Arma;

    private bool sinmunicion;

    [Range(0, 20)]
    public float rangoRotacion = 3;
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            disparar();

        }
        if (sinmunicion)
        {
            Instantiate(Arma);
            sinmunicion = false;
        }

    }

    void disparar()
    {
        if (municionRifle > 0)
        {
            sinmunicion = false;
            GameObject bullet =
               (GameObject)Instantiate(Balas,
                           transform.position,
                           transform.rotation);
            float rotY = Random.Range(-rangoRotacion, rangoRotacion);
            float rotX = Random.Range(-rangoRotacion, rangoRotacion);
            bullet.transform.Rotate(rotX, rotY, 0);
            municionRifle--;
            if (municionRifle == 0)
            {
                sinmunicion = true;
                Debug.Log("Cartucho vacio");
            }
        }
    }

}
