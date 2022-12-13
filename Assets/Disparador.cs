using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject prototipo;
    public float tiempo = 0.3f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempo);
            if (/*Input.GetKey(KeyCode.Space)*/ Input.GetMouseButton(0))
            {
                GameObject laser = (GameObject)Instantiate(prototipo, transform.position, transform.parent.transform.rotation);  
                laser.transform.Rotate(90,90,0);  
            }      
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
