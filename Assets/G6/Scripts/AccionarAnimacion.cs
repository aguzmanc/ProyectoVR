using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Platform.Samples.VrBoardGame;
using OVRTouchSample;

public class AccionarAnimacion : MonoBehaviour
{

    [SerializeField]
    bool agarrado =false;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //bool Cargar = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
        //bool Disparar = OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger);

        bool disparar = OVRInput.Get(OVRInput.Button.One);
        if (disparar){
                anim.SetTrigger("Fire");
        }


    }
}