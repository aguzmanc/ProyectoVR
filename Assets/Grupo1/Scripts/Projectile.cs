using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;           

    public void MoveProjectile(float projectile_speed) {
        rb = GetComponent<Rigidbody>();        
        rb.velocity = /*new Vector3(0f, 0f, projectile_speed)*/ 
            projectile_speed * transform.forward;                
                
        Destroy(this.gameObject, 5f);
    }    

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Target")) {
            Debug.Log("Acierta");
            GameController.Instance.SumarPuntos();
        }
        Destroy(this.gameObject);
    }
}
