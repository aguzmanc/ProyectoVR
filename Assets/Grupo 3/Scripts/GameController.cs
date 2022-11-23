using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<GameObject> _bottles;
    private List<GameObject> _cans;
    private int _score = 0;

    void Start()
    {
        _bottles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Bottle"));
        _cans = new List<GameObject>(GameObject.FindGameObjectsWithTag("Can"));
    }

     public void TargetHit (GameObject go)
        {
            if(_bottles.Contains(go))
            {
                _score += 10;
                _bottles.Remove(go);
                Debug.Log("Score " + _score);
            }else if (_cans.Contains(go))
            {
                _score += 20;
                _cans.Remove(go);
                Debug.Log("Score " + _score);
            }
        }    


}
