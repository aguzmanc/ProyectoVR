using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [Header("Weapon Objects")]
    [SerializeField] private GameObject bullet_prefab;
    [SerializeField] private Transform fire_point;

    [Header("Weapon Stats")]
    [SerializeField] private float fire_ratio = 0.3f;
    [SerializeField] private float projectile_speed = 200f;
    private bool canFire = true;
    
    void Update()
    {
        if (Input.GetButton("Fire1") && canFire) {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() {
        GameObject projectile = GetProjectile();
        projectile.GetComponent<Projectile>().MoveProjectile(projectile_speed);

        canFire = false;
        yield return new WaitForSeconds(fire_ratio);

        canFire = true;
    }

    GameObject GetProjectile() {
        return Instantiate(bullet_prefab, fire_point.position, fire_point.localRotation);
    }
}
