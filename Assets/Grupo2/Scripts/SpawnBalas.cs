using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;

public class SpawnBalas : MonoBehaviour
{
    [SerializeField]
    private GameObject bala;
    [SerializeField]
    private GameObject cargadorVacio;
    [SerializeField]
    private GameObject cargador;
    [SerializeField]
    int segundosControlDisparo;
    [SerializeField]
    bool controladorCorrutina = true;
    [SerializeField]
    bool botonDisparo;
    bool controladorDisparo;
    [SerializeField]
    int contadorBalas;
    [SerializeField]
    int balasCargadorLleno;
    bool confirmarCargadorArma;
    [SerializeField]
    Transform posicionCargador;
    [SerializeField]
    AudioSource recarga;
    [SerializeField]
    AudioSource disparo;
    void Start()
    {
        controladorDisparo = true;
        contadorBalas = balasCargadorLleno;
        confirmarCargadorArma = true;
    }
    void Update()
    {
        /*if ((OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0))
        {
            botonDisparo = true;
        }
        else
        {
            botonDisparo = false;
        }*/
        /*botonDisparo = true;*/
        /*else botonDisparo = false;*/
        if (botonDisparo && controladorCorrutina && controladorDisparo && contadorBalas > 0)
            StartCoroutine(Coroutine(segundosControlDisparo));
        if(contadorBalas == 0 && confirmarCargadorArma){
            Instantiate(cargadorVacio, posicionCargador.transform.position, transform.rotation);
            confirmarCargadorArma = false;
        }
    }
    IEnumerator Coroutine(int segundos)
    {
        Instantiate(bala, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), transform.rotation);
        disparo.Play();
        controladorCorrutina = false;
        controladorDisparo = false;
        contadorBalas -= 1;
        yield return new WaitForSeconds(segundos);
        controladorDisparo = true;
        controladorCorrutina = true;
    }
    public void CambiarCargador()
    {
        contadorBalas = balasCargadorLleno;
        confirmarCargadorArma = true;
        Quaternion rotacionCargador = Quaternion.Euler(0,0,90);
        recarga.Play();
        StartCoroutine(CrearCargador(3, rotacionCargador));
    }
    public bool CargadorEnArma()
    {
        if(contadorBalas>0)
            return true; 
        else return false;
    }
    IEnumerator CrearCargador(int segundos, Quaternion rotacionCargador)
    {
        yield return new WaitForSeconds(segundos);
        Instantiate(cargador, new Vector3(0.2f, 1.2f, -17.5f), rotacionCargador);
    }
}
