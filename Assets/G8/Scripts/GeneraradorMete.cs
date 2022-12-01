using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneraradorMete : MonoBehaviour
{
    public GameObject[] obstaculos;
    public GameObject[] enemigos;
    public GameObject[] huevos;
    float tiempo = 4f;
    public GameObject enemigoNormal;
    public GameObject explometecae;
    public int limiteEnemigos;
    public int enemigosContados;
    // Start is called before the first frame update

    IEnumerator Start()
    {
        limiteEnemigos = 8;
        while (true)
        {
            if (enemigosContados<=limiteEnemigos)
            {
                Generar();
            }   
            yield return new WaitForSeconds(tiempo);
            

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Generar()
    {
        Instantiate(obstaculos[Random.Range(0, obstaculos.Length)], new Vector3(Random.Range(-9, 9), transform.position.y + 100, Random.Range(-52, 57)), Quaternion.Euler(Vector3.up * (Random.Range(0, 4) * 90)));

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MeteoritoNormal")
        {
            

            for (int i = 0; i < huevos.Length; i++)
            {
                int huevoramdon = Random.Range(0, huevos.Length); 
                GameObject enemigo =
                (GameObject)Instantiate(huevos[huevoramdon], new Vector3(other.transform.position.x+Random.Range(-5,5), 0, other.transform.position.z+Random.Range(-5, 5)), other.transform.rotation);
                Destroy(other.gameObject);
                
                
            }
            

        }
        else if (other.tag == "MeteoritoBB")
        {      
                GameObject enemigo =
                (GameObject)Instantiate(enemigoNormal, new Vector3(other.transform.position.x , 0, other.transform.position.z ), other.transform.rotation);
                Destroy(other.gameObject);
                GameObject explision =
                (GameObject)Instantiate(explometecae, new Vector3(other.transform.position.x, 0, other.transform.position.z), other.transform.rotation);


        }
        else if (other.tag == "MeteoritoVerde")
        {
            GameObject enemigo =
            (GameObject)Instantiate(enemigos[0], new Vector3(other.transform.position.x, 0, other.transform.position.z), other.transform.rotation);
            Destroy(other.gameObject);
            GameObject explision =
            (GameObject)Instantiate(explometecae, new Vector3(other.transform.position.x, 0, other.transform.position.z), other.transform.rotation);


        }
        else if (other.tag == "MeteoritoRojo")
        {
            GameObject enemigo =
            (GameObject)Instantiate(enemigos[1], new Vector3(other.transform.position.x, 0, other.transform.position.z), other.transform.rotation);
            Destroy(other.gameObject);
            GameObject explision =
            (GameObject)Instantiate(explometecae, new Vector3(other.transform.position.x, 0, other.transform.position.z), other.transform.rotation);


        }
        else if (other.tag == "MeteoritoMorado")
        {
            GameObject enemigo =
            (GameObject)Instantiate(enemigos[2], new Vector3(other.transform.position.x, 0, other.transform.position.z), other.transform.rotation);
            Destroy(other.gameObject);
            GameObject explision =
            (GameObject)Instantiate(explometecae, new Vector3(other.transform.position.x, 0, other.transform.position.z), other.transform.rotation);


        }


    }
}
