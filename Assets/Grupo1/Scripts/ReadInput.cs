using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string s){        
        PlayerPrefs.SetString("username", s.ToUpper());        
        Debug.Log(PlayerPrefs.GetString("username"));
    }

    public void StartGame() {
        SceneManager.LoadScene("Scene2");
    }
}
