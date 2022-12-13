using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    public OVRInput.Button shootButton;

    private OVRGrabbable grabbable;

    private AudioSource audio;
    [SerializeField] private AudioClip[] audios;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        

    }
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            simpleShoot.StartShoot();
            audio.PlayOneShot(audios[0], 0.6f);
        }
        if (grabbable.isGrabbed && OVRInput.GetDown(shootButton,grabbable.grabbedBy.GetController()))
        {
            simpleShoot.StartShoot();
            audio.PlayOneShot(audios[0], 0.6f);
        }
    }
}
