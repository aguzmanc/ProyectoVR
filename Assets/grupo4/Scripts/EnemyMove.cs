using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float runSpeed = 7f;
    public float rotationSpeed = 250f;
    public Animator animator;
    [SerializeField]
    public Transform pos;
    private float y;
    private int vida = 1;
    void Update()
    {
        

        if(vida<=0){
            animator.SetBool("Death", true);
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        }else{
            transform.LookAt(new Vector3(pos.position.x, transform.position.y, pos.position.z));
            y = 1;
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(pos.position.x, transform.position.y, pos.position.z), y* Time.deltaTime * runSpeed);
            animator.SetFloat("VelY", y);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mjolnir")
        {
            animator.SetBool("Death", true);
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
            StartCoroutine(EsperaSegundos(4));
        }
    }
    IEnumerator EsperaSegundos(int seconds)
    {
      yield return new WaitForSeconds(seconds);
      Destroy(gameObject);
    } 
}
