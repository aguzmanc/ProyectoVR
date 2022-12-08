using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform.Samples.VrBoardGame;

public class AccionarAnimacion : MonoBehaviour
{

    [SerializeField]
    bool agarrado =false;

    Animator anim;

    public void DetectarAgarrado(bool detect) {
        agarrado = detect;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    bool botonDispararA = OVRInput.GetUp(OVRInput.RawButton.A);
    // Update is called once per frame
    void Update()
    {
        if (agarrado == true) {
            if(botonDispararA == true){
                anim.SetTrigger("Fire");
            }

        }
    }
}
