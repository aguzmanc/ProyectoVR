using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguidor : MonoBehaviour
{
    GameObject jugador;
    public float velocidad;
    public bool moverse;
    public float DistanciaAtaque;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "MetalonRojo")
        {
            
            DistanciaAtaque = 5f;
        }
        else if (gameObject.tag == "MetalonVerde")
        {
            
            DistanciaAtaque = 5f;
        }
        else if (gameObject.tag == "MetalonMorado")
        {
            
            DistanciaAtaque = 6f;
        }
        moverse = true;
        jugador = GameObject.FindGameObjectWithTag("Jugador");
    }

    // Update is called once per frame
    void Update()
    {
        if (moverse==true)
        {
            float distancia = CalculateDistanceInSpace();
            Vector3 posJugador = new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z);
            transform.LookAt(posJugador);
            
            if (distancia > DistanciaAtaque)
            {   
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x,0,transform.position.z), posJugador, velocidad * Time.deltaTime);
            }
        }
    

    }
    private float CalculateDistanceInSpace()
    {
        return Vector3.Distance(jugador.transform.position, transform.position);
    }
}
