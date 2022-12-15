using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityPoyect;

public class GameController : MonoBehaviour
{
    private float points;
    public float max_points;
    private string username;
    public int user_id; 

    public float timer;
    private float points_multiplier;
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
        points = 0; max_points = points; points_multiplier = 1f;

        username = PlayerPrefs.GetString("username");
        UserService service = new UserService();
        user_id = service.PostUser(username).idUser;

        updateText();
    }
    
    private void Update() {
        timer += Time.deltaTime;
    }

    public void ActualizarPuntos() {
        if (timer > 10f)
            points_multiplier = curve.Evaluate(10f);            
        else
            points_multiplier = curve.Evaluate(timer);
        
        timer = 0f;
        points = Mathf.Round(points + (10f * points_multiplier));        
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
