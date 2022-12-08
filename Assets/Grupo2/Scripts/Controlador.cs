using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    [SerializeField]
    int totalPuntos = 0;
    [SerializeField]
    Text puntos;
    void Start()
    {
        MostrarPuntos(totalPuntos);
    }
    public void MostrarPuntos(int totalPuntos)
    {
        puntos.text = "Puntaje: " + totalPuntos.ToString();
<<<<<<< HEAD
    }  
=======
    }
>>>>>>> f7f7f99817d6cb8cf05f366baa339cf29fdcfd4c
    public void SumarPuntos(int puntosSumar)
    {
        totalPuntos = totalPuntos + puntosSumar;
        MostrarPuntos(totalPuntos);
    }
}
<<<<<<< HEAD
=======

>>>>>>> f7f7f99817d6cb8cf05f366baa339cf29fdcfd4c
