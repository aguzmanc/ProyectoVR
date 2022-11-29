using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [Header("Weapon Objects")]
    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private Transform fire_point;

    [Header("Weapon Stats")]    
    [SerializeField] private float projectile_speed = 200f;    
    
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.3f) {
            Shoot();
        }
    }

    void Shoot() {
        GameObject projectile = GetProjectile();
        projectile.GetComponent<Projectile>().MoveProjectile(projectile_speed);
    }

    GameObject GetProjectile() {
        return Instantiate(bullet_prefab, fire_point.position, fire_point.localRotation);
    }
}
