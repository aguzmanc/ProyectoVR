using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField]
    Transform _movible;

    [SerializeField]
    Transform _referencia;

    [SerializeField]
    Transform _origen;
    public void SetReferencia(Transform refExterno)
    {
        _referencia = refExterno;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two)) {

        }

        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("bUTTON dOWN SPECIFIC");
        }

        if (_referencia == null)
        {
            return;
        }

        Vector3 miLocal = _origen.InverseTransformPoint(_referencia.position);
        float x = miLocal.x;

        x = Mathf.Max(0.36f, x);
        x = Mathf.Min(8.75f, x);
        _movible.localPosition = new Vector3(x, 0, 0);
    }
}
