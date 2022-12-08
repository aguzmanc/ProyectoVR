using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyDrink : MonoBehaviour
{
    Rigidbody rb;
    Quaternion rotar;
    bool sumaPuntos;
    void Start()
    {
        sumaPuntos = true;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bala" && sumaPuntos)
        {
            sumaPuntos = false;
            rb.isKinematic = false;
            rotar = Quaternion.Euler(90, 0, 45);
            transform.rotation = rotar;
            FindObjectOfType<Controlador>().SumarPuntos(2);
            StartCoroutine(Coroutine(5));
        }
    }
    IEnumerator Coroutine(int segundos)
    {
        yield return new WaitForSeconds(segundos);
        Destroy(gameObject);
    } 
}
