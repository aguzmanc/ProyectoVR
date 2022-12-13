using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaVelocidad : MonoBehaviour
{
    public float velocidad = 50;
    public Puntos puntos;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            Destroy(gameObject);
        }        
    }

    void Update()
    {
        transform.Translate(0, 0, velocidad*Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider otro) 
    {
        if (otro.tag == "Objetivo")
        {
            Destroy(otro.gameObject);
            // Puntos puntos = otro.GetComponentInParent<Puntos>();
            puntos.SumarPuntos();
        }
    }
}
