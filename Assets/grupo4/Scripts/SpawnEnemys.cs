using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField]
    bool couroutineStarted = true;
    [SerializeField]
    private GameObject enemy;
    GameObject inicio;
    bool iniciado;
    int numeroRandom;
    void Start(){
        numeroRandom = Random.Range(2, 8);
    }
    void Update()
    {
        iniciado = FindObjectOfType<ControladorJuego>().ObtenerJuegoIniado();
        if(iniciado){
            if(couroutineStarted){
                StartCoroutine(EsperaSegundos(numeroRandom));
                numeroRandom = Random.Range(12, 17);
            }
        }
    }
    IEnumerator EsperaSegundos(int seconds)
    {
        couroutineStarted = false;
        yield return new WaitForSeconds(seconds);
        Instantiate(enemy, transform.position, transform.rotation);
        couroutineStarted = true;
    } 
}
