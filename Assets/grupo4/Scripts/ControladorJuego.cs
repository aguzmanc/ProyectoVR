using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour
{
    [SerializeField]
    bool _juegoIniciado;
    [SerializeField]
    float min, seg;    
    [SerializeField]
    int puntajeTotal; 
    [SerializeField]
    Text puntaje, temporizador;
    

    void Start()
    {
        _juegoIniciado = false;
        puntajeTotal = 0;
    }

    void Update()
    {
        Debug.Log(_juegoIniciado);
        if (_juegoIniciado)
        {
            if (min >= 0)
                Timer();    
            else
                DetenerJuego();
        }   
    }

    void Timer()
    {
        if (seg > 0)
        {
            seg -= Time.deltaTime;
            if(Mathf.RoundToInt(seg) >= 10) temporizador.text = min + ":" + Mathf.RoundToInt(seg);
            else temporizador.text = min + ":0" + Mathf.RoundToInt(seg);
        }
        else 
        {
            seg = 59;
            min -= 1;
        }
    }

    public void SumarPuntaje(int puntaje)
    {
        puntajeTotal +=puntaje;
        MostrarPuntaje(puntajeTotal);
    }
    public void MostrarPuntaje(int puntajeTotal)
    {
        puntaje.text = puntajeTotal.ToString();
    }  

    public bool ObtenerJuegoIniado()
    {
        return _juegoIniciado;
    }

    public void IniciarJuego()
    {
        _juegoIniciado = true;
    }

    public void DetenerJuego()
    {
        _juegoIniciado = false;
    }
}
