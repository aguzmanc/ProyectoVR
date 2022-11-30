using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private GameObject[] bullet;
    //[SerializeField]
    //private ParticleSystem particle;
    [SerializeField]
    private Transform movimiento;
    private int rango;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 180;
    }

    void EventoDisparar()
    {
        GameObject projectile = AgarrarBala();
        projectile.GetComponent<Bullet>().MovimientoBala(velocidad);
        //Particulas();
    }

    GameObject AgarrarBala()
    {
        rango = Random.Range(0, bullet.Length);
        return Instantiate(bullet[rango], movimiento.position, movimiento.localRotation);
    }

    /*void Particulas()
    {
        ParticleSystem particleSystem = Instantiate(particle, movimiento.position, movimiento.localRotation);
        Destroy(particleSystem.gameObject, particleSystem.main.duration);
    }*/

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            EventoDisparar();
        }
    }
}
