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
    public float shoot_miss_decreaser;
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
        points = 0; max_points = points; points_multiplier = 1f; shoot_miss_decreaser = 0f;
        username = PlayerPrefs.GetString("username");
        UserService service = new UserService();
        user_id = service.PostUser(username).idUser;
        Debug.Log(service.GetUserDetails());

        UpdateText();        
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
        float multiplier = (15f * points_multiplier);
        points = Mathf.Round(points + (multiplier - (multiplier * shoot_miss_decreaser))); 
        shoot_miss_decreaser = 0f;       
        UpdateText();
    }

    private void MaximoPuntaje() {        
        if (points > max_points) {
            max_points = points;
        }
    }

    public void ReiniciarPuntos() {
        MaximoPuntaje();
        points = 0;        
        UpdateText();
    }

    private void UpdateText() {
        textScore.text = $"{points.ToString()} pts.";
    }
}
