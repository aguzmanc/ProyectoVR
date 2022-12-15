using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    public Text input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ReadStringInput(input.text);
            StartGame();
        }
    }

    public void ReadStringInput(string s){        
        PlayerPrefs.SetString("username", s.ToUpper());        
        Debug.Log(PlayerPrefs.GetString("username"));
    }

    public void StartGame() {
        SceneManager.LoadScene("Scene2");
    }
}
