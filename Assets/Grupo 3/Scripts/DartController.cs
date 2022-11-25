using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour
{
    public GameController gameController;
    private float liveTime = 5.0f;
    private bool temporal = false;
    void Update()
    {
        if(temporal && liveTime<=0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision obj) {
        gameController.TargetHit(obj.gameObject);
    }
    public void SetAsTemporal()
    {
        temporal=true;
    }
}
