using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSTarget : MonoBehaviour
{
    [SerializeField]
    Vector3 principle, end;
    
    private float t = 0.1f;

    bool adelante, atras;

    void Start()
    {
        principle = transform.position;
        end = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == principle) {
            adelante = true;
            atras = false;
        }

        if (transform.position == end) {
            adelante = false;
            atras = true;
        }

        if (adelante) {
            transform.position = Vector3.Lerp(transform.position, end, t);
        }
        
        if (atras) {
            transform.position = Vector3.Lerp(transform.position, principle, t);
        }

    }
}
