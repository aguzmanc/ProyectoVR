using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;

    private AudioSource controlAudio;
    // Start is called before the first frame update
    
    private void Awake()
    {
        controlAudio=GetComponent<AudioSource>();
    }


    public void SeleccionAudio(int indice,float volumen)
    {
        if (!controlAudio.isPlaying)
        {
            controlAudio.PlayOneShot(audios[indice], volumen);
        }
        

    }

}
