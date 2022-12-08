using Oculus.Platform.Samples.VrBoardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject Balas;
    private int municionRifle = 30;
    public GameObject Arma;

    public AudioSource controlSonido; //Controlar el Sonido
    public AudioClip sonidoDisparo; //Reproducir Sonido
    public AudioClip sonidoSinBalas; 
    private bool sinmunicion;
    Vector3 position;


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
            Quaternion rotation = new Quaternion(0f,0f,0f,0f);
            position = new Vector3(0.926f,0.771f,0);
            Destroy(Arma);
            Instantiate(Arma, position, rotation);
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
            if (sinmunicion == false)
            {
                controlSonido.PlayOneShot(sonidoDisparo);
            }
            if (municionRifle == 0)
            {
                sinmunicion = true;
                Debug.Log("Cartucho vacio");
                controlSonido.PlayOneShot(sonidoSinBalas);
            }
            if (sinmunicion == true)
            {
                controlSonido.PlayOneShot(sonidoSinBalas);
            }
        }
    }
}
