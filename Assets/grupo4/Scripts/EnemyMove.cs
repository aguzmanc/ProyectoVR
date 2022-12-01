using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float runSpeed = 7f;
    public float rotationSpeed = 250f;
    public Animator animator;
    [SerializeField]
    public Transform pos;
    private float y;
    private int vida = 1;
    bool muerte = false;
    bool atack = false;
    public GameObject ove;
    public NavMeshAgent agente;

    void Start(){
        ove = GameObject.Find("OVRCameraRig");
        pos = ove.transform;
    }
    void Update()
    {
        if(vida<=0){
            animator.SetBool("Death", true);
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        }else{
            
            transform.LookAt(new Vector3(pos.position.x, transform.position.y, pos.position.z));
            y = 1;
            if(!muerte&&!atack){
                //transform.position = Vector3.MoveTowards(transform.position,new Vector3(pos.position.x, transform.position.y, pos.position.z), y* Time.deltaTime * runSpeed);
                agente.enabled = true;
                agente.SetDestination(pos.position);
            }
            animator.SetFloat("VelY", y);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mjolnir")
        {
            if(!muerte){
                agente.enabled = false;
                muerte = true;
                StartCoroutine(RestarPuntos(false));
                FindObjectOfType<ControladorJuego>().SumarPuntaje(1);
                animator.SetBool("Atack", false);
                animator.SetBool("Death", true);
                atack = false;
                transform.position = new Vector3(transform.position.x,0,transform.position.z);
                StartCoroutine(EsperaSegundos(4));
            }
        }else if(other.tag == "Player")
        {
            if(!muerte){
                agente.SetDestination(transform.position);
                animator.SetBool("Atack", true);
                atack = true;
                transform.position = new Vector3(transform.position.x,0,transform.position.z);
                StartCoroutine(RestarPuntos(true));
            }
        }
        
    }

    IEnumerator RestarPuntos(bool real){
        while(real&&muerte==false){
            FindObjectOfType<ControladorJuego>().RestarPuntaje(1);
            yield return new WaitForSeconds(1.3f);
        }
        
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player")
        {
            animator.SetBool("Atack", false);
            atack = false;
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        }
    }
    IEnumerator EsperaSegundos(int seconds)
    {
      yield return new WaitForSeconds(seconds);
      Destroy(gameObject);
    } 
}
