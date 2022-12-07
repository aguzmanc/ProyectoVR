using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misilvelocidad : MonoBehaviour
{
    // Start is called before the first frame update
    public float velomisil = 50;

    public float tiempovida = 5f;
    IEnumerator Start()
    {

        while (true)
        {
            yield return new WaitForSeconds(tiempovida);

            Destroy(gameObject);

        }

    }


    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(0, 0, -velomisil * Time.deltaTime));

    }
}