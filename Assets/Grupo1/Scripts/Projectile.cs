using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;    
    private float speed;

    public void MoveProjectile(float projectile_speed) {
        // rb = GetComponent<Rigidbody>();        
        // rb.AddForce(transform.forward * projectile_speed);
        // transform.Translate(new Vector3(0f, 0f, projectile_speed));
        speed = projectile_speed;
        Destroy(this.gameObject, 5f);
    }

    private void Update() {
        transform.Translate(new Vector3(0f, 0f, speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
}
