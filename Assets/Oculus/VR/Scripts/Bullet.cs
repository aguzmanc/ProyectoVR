using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 5;
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovimientoBala(float velocidad)
    {
        rigidbody.AddRelativeForce(Vector3.forward * velocidad, ForceMode.Impulse);
        Destroy(this.gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
