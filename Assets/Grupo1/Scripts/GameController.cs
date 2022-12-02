using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int points;
    [SerializeField] private Text textScore;

    public static GameController Instance { get; private set;}

    private void Awake() {
        if (Instance != null && Instance != this) { 
            Destroy(this); 
        } 
        else { 
            Instance = this; 
        } 
    }
    
    private void Start() {
        points = 0;
        textScore.text = $"{points.ToString()} pts.";
    }
    
    public void SumarPuntos() {
        points += 10;
        textScore.text = $"{points.ToString()} pts.";
    }

    public void ReiniciarPuntos() {
        points = 0;
        textScore.text = $"{points.ToString()} pts.";
    }
}
