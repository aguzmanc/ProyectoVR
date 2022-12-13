using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public int puntos = 0;
    public Text ScoreText;

    void Start()
    {
        ScoreText.text = "Puntaje: 0";
        puntos = 0;
    }

    public void SumarPuntos()
    {
        puntos += 10;
        print(puntos);
        ScoreText.text = $"Puntaje: {puntos}";
    }
}
