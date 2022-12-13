using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionObjetivo : MonoBehaviour
{
    [SerializeField] PuntajeManager ScoreManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "apple")
        {
            ScoreManager.AddPoints();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
