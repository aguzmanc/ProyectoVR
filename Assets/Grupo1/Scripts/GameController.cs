using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityPoyect;

public class GameController : MonoBehaviour
{    
    [Header("Usuario")]
    public string username;
    public int user_id; 
    
    [Header("Sistema puntaje")]
    public float points_to_plus;
    public float points;
    public float max_points;
    public float timer;
    public float points_multiplier;
    [SerializeField] private AnimationCurve curve;
    public float shoot_miss_decreaser;    
    
    [Header("UI")]    
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
        
        if (timer > 10f)
            points_multiplier = curve.Evaluate(10f);            
        else
            points_multiplier = curve.Evaluate(timer);

        float multiplier = (15f * points_multiplier);
        points_to_plus = Mathf.Round(points + (multiplier - (multiplier * shoot_miss_decreaser)));
    }

    public void ActualizarPuntos() {
        
        
        timer = 0f;
        
        points = points_to_plus; 
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
