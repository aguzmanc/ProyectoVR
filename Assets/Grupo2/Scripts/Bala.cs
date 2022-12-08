using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]
    float velocidad;
    void Update()
    {
        transform.Translate(0,0,velocidad * Time.deltaTime);
        StartCoroutine(Coroutine(5));
    }

    IEnumerator Coroutine(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        Destroy(gameObject);
    } 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Puntaje" || other.tag == "Terreno" || other.tag == "lata")
        {
            Destroy(gameObject);
        }
    }
}
