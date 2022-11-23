using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject prototipoLaser;

    public float tiempo = 0.3f;

    [Range(0,20)]
    public float rangoRotacion = 3;
    IEnumerator Start()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(tiempo);
            
            if(Input.GetMouseButton(0)){
                GameObject laser = 
                    (GameObject)Instantiate(prototipoLaser, transform.position, transform.rotation);

                float rotX = Random.Range(-rangoRotacion, rangoRotacion);
                float rotY = Random.Range(-rangoRotacion, rangoRotacion);
                
                laser.transform.Rotate(rotX,rotY,0);

                Destroy(laser, 3.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
