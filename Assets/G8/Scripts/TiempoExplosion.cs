using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoExplosion : MonoBehaviour
{
    public float tiempo;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(tiempo);
        Destroy(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
