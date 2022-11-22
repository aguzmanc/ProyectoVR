using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandVRAnimatorController : MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    public float _agarre;

    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        //_agarre = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger);
        _anim.SetFloat("Pinch", _agarre);
    }
}
