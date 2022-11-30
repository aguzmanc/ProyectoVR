using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveGenerate : MonoBehaviour
{
    
    
    [SerializeField] GameObject objectivePrefab;
    [SerializeField] float minDifference = 20;
    bool right;
    bool left;

    Vector3 result;
    Vector3 a, b;
    float t;
    Vector3 izq, der;
    

    IEnumerator Start() {
        izq = transform.position;
        der = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f);
        while(true){
            yield return new WaitForSeconds(5);
            //Instantiate(objectivePrefab);
        }

    }

    void Update()
    {
        

        //t += Time.deltaTime * 0.1f;
        t = 5f * Time.deltaTime;
        

        
        if (transform.position == izq)
        {

            left = false;
            right = true;
           Debug.Log("Left false");

        }
        if(transform.position == der){
            left = true;
            right = false;
            Debug.Log("Left true");
        }
        if (right)
        {
            transform.position = Vector3.Lerp(transform.position,der,t);
            Debug.Log("derecha");
        }

        if (left)
        {
            transform.position = Vector3.Lerp(transform.position,izq,t);
            Debug.Log("izquierda");

        }
    }


}
