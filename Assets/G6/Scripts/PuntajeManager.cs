using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeManager : MonoBehaviour
{
    public int Points { get; set; } = 0;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Puntaje: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        Points += 10;
        ScoreText.text = $"Puntaje: {Points}";
    }
}
