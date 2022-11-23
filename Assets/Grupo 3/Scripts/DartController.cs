using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour
{
    public GameController gameController;

    void OnCollisionEnter(Collision other) {
        gameController.TargetHit(other.gameObject);
    }
}
