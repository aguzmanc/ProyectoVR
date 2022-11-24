using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private List<GameObject> _bottles;
    private List<GameObject> _cans;
    private int _score = 0;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        _bottles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bottle"));
        _cans = new List<GameObject>(GameObject.FindGameObjectsWithTag("Can"));
    }

     public void TargetHit (GameObject go)
        {
            if(_bottles.Contains(go))
            {
                _score += 10;
                _bottles.Remove(go);
                Debug.Log("Score: " + _score);
                scoreText.text = "Score: " + _score;
            }else if (_cans.Contains(go))
            {
                _score += 20;
                _cans.Remove(go);
                Debug.Log("Score " + _score);
                scoreText.text = "Score: " + _score;
            }
        }    


}
