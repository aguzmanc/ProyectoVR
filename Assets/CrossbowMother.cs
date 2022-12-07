using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowMother : MonoBehaviour
{
    [SerializeField]
    Transform _movible, _origen;
    Transform _referencia;

    public void SetReferencia(Transform refExterno)
    {
        _referencia = refExterno;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_referencia == null)
            return;

        Vector3 local = _origen.InverseTransformPoint(_referencia.position);
        
        float x = local.x;
        float y = local.y;     
        
        _movible.localPosition = new Vector3(x, y, 0);
    }
}
