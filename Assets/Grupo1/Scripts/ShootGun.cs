using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField] private AgarreMano agarreMano;

    [Header("Weapon Objects")]
    [SerializeField] private GameObject bullet_prefab;    
    [SerializeField] private Transform fire_point;

    [Header("Weapon Effects")]
    [SerializeField] private ParticleSystem fx_smoke;
    [SerializeField] private ParticleSystem fx_muzzleFlash;
    [SerializeField] private ParticleSystem fx_beam;

    [Header("Weapon Sounds")]
    [SerializeField] private AudioClip[] shoots;
    [SerializeField] private AudioClip empty;
    AudioSource audioSource;    

    [Header("Weapon Stats")]    
    [SerializeField] private float projectile_speed = 200f;
    [SerializeField] private int ammunition = 30;          
    
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && agarreMano.agarrado) {
            Shoot();
        }

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        if (ammunition > 0) {
            GameObject projectile = GetProjectile();            
            projectile.GetComponent<Projectile>().MoveProjectile(projectile_speed);
            FlashEffect();                        
            ammunition --;
        }           

        PlayShootSound();
    }

    void PlayShootSound() {  
         if (ammunition > 0) {
            int rnd = Random.Range(0, shoots.Length);
            audioSource.clip = shoots[rnd];
         } else {
            audioSource.clip = empty;
         }   
        
        audioSource.Play();                    
    }

    GameObject GetProjectile() {        
        return Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
    }

    void FlashEffect() {
        ParticleSystem ps_smoke = Instantiate(fx_smoke, fire_point.position, fire_point.rotation);
        ParticleSystem ps_muzzle = Instantiate(fx_muzzleFlash, fire_point.position, fire_point.rotation);
        ParticleSystem ps_beam = Instantiate(fx_beam, fire_point.position, fire_point.rotation);
        Destroy(ps_smoke.gameObject, ps_smoke.main.duration);
        Destroy(ps_muzzle.gameObject, ps_muzzle.main.duration);
        Destroy(ps_beam.gameObject, ps_beam.main.duration);        
    }

    public void ResetAmmunation() {
        ammunition = 30;
        GameController.Instance.ReiniciarPuntos();
    }

}
