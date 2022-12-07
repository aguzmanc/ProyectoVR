using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugadorCompleto : MonoBehaviour
{
    public float vidaJugador=1000;
    public float eliminaciones = 0;
    public Slider slidervida;
    public Text eliminacionestexto;
    public bool estado;
    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;
    public GameObject[] trofeos;
    int trofeoscantidad = 0;
    public Image fondo;
    public Image felicidades;
    float delay = 1f;
    float elapsed;
    // Start is called before the first frame update
    
    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
        estado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!estado)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= delay)
            {

                if (!controlAudio.isPlaying)
                {
                    controlAudio.PlayOneShot(audios[0], 0.5f);

                }
                elapsed = 0;
                estado = true;


            }
            
        }
        
        slidervida.value = vidaJugador;
        eliminacionestexto.text = eliminaciones.ToString();

        

        if (vidaJugador <= 0)
        {
            if (eliminaciones >= 50 && trofeoscantidad<=0)
            {
                Instantiate(trofeos[2], new Vector3(0, 0 + 0, 0), Quaternion.Euler(Vector3.up * (Random.Range(0, 4) * 90)));
                trofeoscantidad = trofeoscantidad + 1;
                fondo.enabled = fondo.enabled;
                felicidades.enabled = felicidades.enabled;
                controlAudio.clip = audios[1];
                controlAudio.loop = true;
                controlAudio.PlayOneShot(audios[1], 0.8f);
            }
            else if (eliminaciones >= 20 && eliminaciones < 50 && trofeoscantidad <= 0)
            {
                Instantiate(trofeos[1], new Vector3(0, 0 + 0, 0), Quaternion.Euler(Vector3.up * (Random.Range(0, 4) * 90)));
                trofeoscantidad = trofeoscantidad + 1;
                fondo.enabled = fondo.enabled;
                felicidades.enabled = felicidades.enabled;
                controlAudio.clip = audios[1];
                controlAudio.loop = true; 
                controlAudio.PlayOneShot(audios[1], 0.8f);
            }
            else if (eliminaciones >= 0 && eliminaciones < 20 && trofeoscantidad <= 0)
            {
                Instantiate(trofeos[0], new Vector3(0, 0 + 0, 0), Quaternion.Euler(Vector3.up * (Random.Range(0, 4) * 90)));
                trofeoscantidad = trofeoscantidad + 1;
                fondo.enabled = fondo.enabled;
                controlAudio.clip = audios[1];
                felicidades.enabled = felicidades.enabled;
                controlAudio.loop = true;
                controlAudio.PlayOneShot(audios[1], 0.8f);
            }

        }
        if (eliminaciones >= 50 && trofeoscantidad <= 0)
        {
            Instantiate(trofeos[2], new Vector3(0, 0 + 0, 0), Quaternion.Euler(Vector3.up * (Random.Range(0, 4) * 90)));
            trofeoscantidad = trofeoscantidad + 1;
            fondo.enabled = fondo.enabled;
            felicidades.enabled = felicidades.enabled;
            controlAudio.clip = audios[1];
            controlAudio.loop = true;
            controlAudio.PlayOneShot(audios[1], 0.8f);
        }




    }
}
