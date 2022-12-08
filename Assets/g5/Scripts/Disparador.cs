using Oculus.Platform.Samples.VrBoardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Disparador : MonoBehaviour
{
    public GameObject generador;

    Vector3 position;
    public GameObject Arma;

    public GameObject Balas;
    //public int municionRifle = 30;

    private int municionRifle = 10;

    [SerializeField]
    public int MunicionRifle
    {
        get { return municionRifle; }
        set { municionRifle = value; }
    }



    public AudioSource controlSonido; //Controlar el Sonido
    public AudioClip sonidoDisparo; //Reproducir Sonido
    public AudioClip sonidoSinBalas; 
    public bool sinmunicion;


    [Range(0, 20)]
    public float rangoRotacion = 3;
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            disparar();
            if (sinmunicion)
            {
                Debug.Log("Estamos sin municion");
                Quaternion rotation = new Quaternion(0f, 90f, 0f, 0f);
                position = generador.transform.position;
                Destroy(Arma);
                Instantiate(Arma, position, rotation);
                Arma.transform.position = new Vector3();
                sinmunicion = false;
            }

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
