using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionObjetivo : MonoBehaviour
{
    [SerializeField] PuntajeManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "apple")
        {
            PuntajeManager.AddPoints();
            Destroy(otro.gameObject);
            Destroy(gameObject);
        }
    }
}
