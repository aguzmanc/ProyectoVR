using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private float points;
    private float max_points;
    private string username;

    [SerializeField] private AnimationCurve curve;
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
        max_points = points;
        username = PlayerPrefs.GetString("username");
        updateText();
    }
    
    public void ActualizarPuntos() {
        points = points + 10f;        
        updateText();
    }

    private void MaximoPuntaje() {        
        if (points > max_points) {
            max_points = points;
        }
    }

    public void ReiniciarPuntos() {
        MaximoPuntaje();
        points = 0;        
        updateText();
    }

    private void updateText() {
        textScore.text = $"{points.ToString()} pts.";
    }
}
