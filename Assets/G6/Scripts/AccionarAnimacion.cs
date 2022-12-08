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

    // Update is called once per frame
    void Update()
    {
            bool Cargar = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
            bool Disparar = OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger);

        if (Cargar == true){
                anim.SetTrigger("Hold");
            }

        if (Disparar == true)
        {
            Debug.Log("Fire");
            anim.SetTrigger("Fire");
        }


    }
}
