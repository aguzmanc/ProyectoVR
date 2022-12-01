using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;    

    public void MoveProjectile(float projectile_speed) {
        rb = GetComponent<Rigidbody>();        
        rb.AddRelativeForce(transform.forward * projectile_speed);
        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
}
