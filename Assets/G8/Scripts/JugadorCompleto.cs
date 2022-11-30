using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorCompleto : MonoBehaviour
{
    float vidaJugador;
    public Slider slidervida;
    // Start is called before the first frame update
    void Start()
    {
        vidaJugador = 100;
    }

    // Update is called once per frame
    void Update()
    {
        slidervida.value = vidaJugador;
        
    }
}
