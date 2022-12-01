using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [Header("Weapon Objects")]
    [SerializeField] private GameObject[] bullet_prefab;
    [SerializeField] private ParticleSystem fx_flash;
    [SerializeField] private Transform fire_point;

    [Header("Weapon Stats")]    
    [SerializeField] private float projectile_speed = 200f;    
    
    void Update()
    {
        // if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) {
        //     Shoot();
        // }

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        GameObject projectile = GetProjectile();            
        projectile.GetComponent<Projectile>().MoveProjectile(projectile_speed);
        FlashEffect();
    }

    GameObject GetProjectile() {
        int rnd = Random.Range(0, bullet_prefab.Length);
        return Instantiate(bullet_prefab[rnd], fire_point.position, fire_point.rotation);
    }

    void FlashEffect() {
        ParticleSystem ps = Instantiate(fx_flash, fire_point.position, fire_point.rotation);
        Destroy(ps.gameObject, ps.main.duration);
    }

}
