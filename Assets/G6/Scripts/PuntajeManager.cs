using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeManager : MonoBehaviour
{
    public int Points { get; set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        Points += 10;
    }
}
