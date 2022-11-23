using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MjolnirActions : MonoBehaviour
{
    [SerializeField]
    bool agarrado;
    [SerializeField]
    float velocidad = 50;
    [SerializeField]
    Rigidbody rigidbody;
    [SerializeField]
    bool vuelo = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        agarrado = GetComponent<OVRGrabbable>().isGrabbed;
        if(!agarrado && transform.position.y >= 1.4f || vuelo)
        {
            rigidbody.isKinematic = true;
            transform.Translate(new Vector3(0f,velocidad * Time.deltaTime,0f),Space.Self);
            vuelo = true;
        } 
        if(!agarrado && transform.position.y <= 0.35f)
        {
            vuelo = false;
            rigidbody.isKinematic = false;
        }
    }
}
