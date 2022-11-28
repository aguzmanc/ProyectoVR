using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class AnimatedControllerDos : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private bool _animateWhenRun = true;
    private static readonly int MovingHash = Animator.StringToHash("Run Forward");
    private static readonly int AttackHash = Animator.StringToHash("Stab Attack");
    private static readonly int HitHash = Animator.StringToHash("Take Damage");
    private static readonly int IsDeadHash = Animator.StringToHash("Die");

    public Seguidor seguidor;
    GameObject jugador;
   

    
    private float life = 400;
    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador");
       // seguidor = FindObjectOfType<Seguidor>();
        seguidor = gameObject.GetComponentInParent<Seguidor>();
    }
    IEnumerator RecibirGolpeVivo()
    {
        _animator.SetBool(MovingHash, false);
        seguidor.moverse = false;
        _animator.SetBool(HitHash, true);
        _animateWhenRun = false;
        yield return new WaitForSeconds(2);
        _animateWhenRun = true;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "RashoLaser")
        {
            seguidor.moverse = false;
            _animateWhenRun = false;
               life = life - 50;
            if (life > 0)
            {
                RecibirGolpeVivo();
            }
            else
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(IsDeadHash, true);
                Destroy(gameObject);
            }
            seguidor.moverse = true;

        }
        else if (other.tag=="Katanazo")
        {
            
            life = life - 100;
            if (life > 0)
            {
                RecibirGolpeVivo();
            }
            else
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(IsDeadHash, true);
                seguidor.moverse = false;
                Destroy(gameObject);
            }
            
        }



    }

 

    private void Update()
    {


        if (_animateWhenRun)
        {
            var tr = transform;
            var position = tr.position;
            float distancia = CalculateDistanceInSpace();

            if (distancia > 4f)
            {
                
                _animator.SetBool(MovingHash, true);
                
            }
            else
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(AttackHash, true);

            }

            
        }
    }
    private float CalculateDistanceInSpace()
    {
        return Vector3.Distance(jugador.transform.position, transform.position);
    }

    private void OnValidate()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    public void SetMovingState(bool val)
    {
        _animator.SetBool(MovingHash, val);
    }

    public void SetDead()
    {
        _animator.SetBool(IsDeadHash, true);
    }
    public void ClearDead()
    {
        _animator.SetBool(IsDeadHash, false);
        _animator.Play("Idle");
    }
    public void Attack()
    {
        _animator.SetTrigger(AttackHash);
    }

    public void Hit()
    {
        _animator.SetTrigger(HitHash);
    }

    public bool IsMoving
    {
        get { return _animator.GetBool(MovingHash); }
    }
}
