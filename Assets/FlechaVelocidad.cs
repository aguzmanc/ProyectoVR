using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaVelocidad : MonoBehaviour
{
    public float velocidad = 50;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }        
    }
    void Update()
    {
        transform.Translate(0, 0, velocidad*Time.deltaTime, Space.Self);
    }
}
