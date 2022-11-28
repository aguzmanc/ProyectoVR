using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguidor : MonoBehaviour
{
    GameObject jugador;
    public float velocidad;
    public bool moverse;

    // Start is called before the first frame update
    void Start()
    {
        moverse = true;
        jugador = GameObject.FindGameObjectWithTag("Jugador");
    }

    // Update is called once per frame
    void Update()
    {
        if (moverse==true)
        {
            float distancia = CalculateDistanceInSpace();
            if (distancia > 4f)
            {

                Vector3 posJugador = new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z);
                transform.LookAt(posJugador);
                transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
            }
        }
        

        

       

    }
    private float CalculateDistanceInSpace()
    {
        return Vector3.Distance(jugador.transform.position, transform.position);
    }
}
