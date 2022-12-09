using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargadorVacio : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(Coroutine(4));
    }
    IEnumerator Coroutine(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        Destroy(gameObject);
    }
}
