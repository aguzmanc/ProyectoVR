using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField]
    bool couroutineStarted = true;
    [SerializeField]
    private GameObject enemy;
    void Update()
    {
        if(couroutineStarted){
        int numeroRandom = Random.Range(1, 6);
        StartCoroutine(EsperaSegundos(numeroRandom));
        }
    }
    IEnumerator EsperaSegundos(int seconds)
    {
        couroutineStarted = false;
        yield return new WaitForSeconds(seconds);
        Instantiate(enemy);
        couroutineStarted = true;
    } 
}
