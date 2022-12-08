using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateWeapon : MonoBehaviour
{
    
    Vector3 position;
    public GameObject Arma;
    Disparador disparador;
    // Start is called before the first frame update
    void Start()
    {
        disparador = new Disparador();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(disparador.MunicionRifle + " Estas balass");
        if (disparador.MunicionRifle <= 0)
        {
            Debug.Log("Estamos sin municion");
            Quaternion rotation = new Quaternion(0f, 0f, 180f, 0f);
            position = generador.transform.position;
            Destroy(Arma);
            Instantiate(Arma, position, rotation);
            disparador.sinmunicion = false;
        }

    }
}
