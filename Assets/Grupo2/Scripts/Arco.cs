using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    [SerializeField]
    private GameObject arco;
    Rigidbody rb;
    int x, y, z, randomCaida;
    Quaternion rotacionInicio;
    Quaternion rotar;
    bool sumaPuntos;
    void Start()
    {
        sumaPuntos = true;
        x = Random.Range(-10, 11);
        y = Random.Range(2, 6);
        z = Random.Range(-10, 11);
        randomCaida = Random.Range(0, 2);
        rb = GetComponent<Rigidbody>();
        rotacionInicio = transform.rotation;
        rb.isKinematic = true;
    }
    private void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
        if(other.tag == "Bala" && sumaPuntos)
        {
            sumaPuntos = false;
            rb.isKinematic = false;
            if(randomCaida < 1) rotar = Quaternion.Euler(-90, 0, 0);
=======
        if (other.tag == "Bala" && sumaPuntos)
        {
            sumaPuntos = false;
            rb.isKinematic = false;
            if (randomCaida < 1) rotar = Quaternion.Euler(-90, 0, 0);
>>>>>>> f7f7f99817d6cb8cf05f366baa339cf29fdcfd4c
            else rotar = Quaternion.Euler(90, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotar, Time.deltaTime);
            FindObjectOfType<Controlador>().SumarPuntos(5);
            StartCoroutine(Coroutine(5));
        }
    }
    IEnumerator Coroutine(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        Instantiate(arco, new Vector3(x, y, z), rotacionInicio);
        Destroy(gameObject);
<<<<<<< HEAD
    } 
=======
    }
>>>>>>> f7f7f99817d6cb8cf05f366baa339cf29fdcfd4c
}
