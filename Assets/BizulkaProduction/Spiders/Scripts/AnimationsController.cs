using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class AnimationsController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _animateWhenRun = true;
    private static readonly int MovingHash = Animator.StringToHash("IsMoving");
    private static readonly int AttackHash = Animator.StringToHash("Attack");
    private static readonly int HitHash = Animator.StringToHash("Hit");
    private static readonly int IsDeadHash = Animator.StringToHash("IsDead");

    public SeguidorDos seguidor;
    GameObject jugador;
    public float life;



    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador");
        seguidor = gameObject.GetComponentInParent<SeguidorDos>();
        if (gameObject.tag == "Aranabb")
        {
            life = 50;
          
        }
        else if (gameObject.tag == "AranaCafe")
        {
            life = 300;
            
        }
        else if (gameObject.tag == "AranaVerde")
        {
            life = 400;
            
        }
        else if (gameObject.tag == "AranaRoja")
        {
            life = 500;
            
        }
    }

    IEnumerator RecibirGolpeVivo()
    {
        _animateWhenRun = false;
        seguidor.moverse = false;
        _animator.SetBool(MovingHash, false);
        _animator.SetBool(AttackHash, false);
        _animator.SetBool(HitHash, true);

        yield return new WaitForSeconds(2);
        _animator.SetBool(MovingHash, true);
        seguidor.moverse = true;
        _animateWhenRun = true;
    }

    IEnumerator UltimoAliento()
    {
        _animateWhenRun = false;
        seguidor.moverse = false;
        _animator.SetBool(MovingHash, false);
        _animator.SetBool(IsDeadHash, true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "RashoLaser")
        {

            life = life - 50;
            if (life > 0)
            {
                StartCoroutine(RecibirGolpeVivo());
            }
            else
            {
                StartCoroutine(UltimoAliento());


            }


        }
        else if (other.tag == "Katanazo")
        {

            life = life - 100;
            if (life > 0)
            {
                StartCoroutine(RecibirGolpeVivo());
            }
            else
            {
                StartCoroutine(UltimoAliento());
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

            if (distancia > 2.5f)
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
        return Vector3.Distance(jugador.transform.position,transform.position);
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