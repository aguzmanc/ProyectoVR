using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSTarget : MonoBehaviour
{
    [SerializeField]
    Vector3 principle, end;
    
    private float t = 0.1f;

    bool derecha, izquierda;

    void Start()
    {
        principle = transform.position;
        end = new Vector3(transform.position.x +3f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == principle) {
            derecha = true;
            izquierda = false;
        }

        if (transform.position == end) {
            derecha = false;
            izquierda = true;
        }

        if (derecha) {
            transform.position = Vector3.Lerp(transform.position, end, t);
        }
        
        if (izquierda) {
            transform.position = Vector3.Lerp(transform.position, principle, t);
        }

    }
}
