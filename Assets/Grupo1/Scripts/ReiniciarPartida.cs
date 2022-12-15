using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityPoyect;

public class ReiniciarPartida : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("Bala")) {
            ScoreService service = new ScoreService();
            service.PostScore(GameController.Instance.user_id, GameController.Instance.max_points);
            //SceneManager.UnloadSceneAsync("Scene2");
            SceneManager.LoadScene("SceneStart");
        }
    }
}
