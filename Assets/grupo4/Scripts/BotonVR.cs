using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BotonVR : MonoBehaviour
{
    [SerializeField]
    Transform cuboClick;

    Vector3 posPresionado, posOriginal;
    public UnityEvent cuandoPresion;

    public void Presionar()
    {
        posPresionado = posOriginal - Vector3.up * 0.2f;
        cuboClick.localPosition = posPresionado;
        CambiarColorComponente(cuboClick, Color.green);
        cuandoPresion.Invoke();
    }

    public void Soltar()
    {
        posPresionado = posOriginal + Vector3.up * 0.2f;
        cuboClick.localPosition = posPresionado;
        CambiarColorComponente(cuboClick, Color.red);
    } 

    public void CambiarColorComponente(Transform transform, Color color)
    {
        MeshRenderer mesh = transform.GetComponent<MeshRenderer>();
        mesh.material.color = color;
    }
}
