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
    private static readonly int JumpHash = Animator.StringToHash("Jump");

    public Seguidor seguidor;
    GameObject generador;
    GeneraradorMete gene;
    GameObject jugador;
    public float life;
    float DistanciaAtaque;
    GameObject padre;
    float delay=0.1f;
    float elapsed;

    private void Start()
    {
        
        jugador = GameObject.FindGameObjectWithTag("Jugador");
        seguidor = gameObject.GetComponentInParent<Seguidor>();
        generador= GameObject.FindGameObjectWithTag("Detector");
        gene = generador.GetComponentInParent<GeneraradorMete>();

        padre = gameObject.transform.parent.gameObject;
        StartCoroutine(InicioSaltarin());
        if (gameObject.tag=="MetalonRojo")
        {
            life = 400;
            DistanciaAtaque = 5f;
        }
        else if (gameObject.tag == "MetalonVerde")
        {
            life = 300;
            DistanciaAtaque = 5f;
        }
        else if (gameObject.tag == "MetalonMorado")
        {
            life = 600;
            DistanciaAtaque = 6f;
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
        Destroy(padre);
        gene.enemigosContados = gene.enemigosContados - 1;
    }
    IEnumerator UltimoAlientoRasho()
    {
        _animateWhenRun = false;
        seguidor.moverse = false;
        _animator.SetBool(MovingHash, false);
        _animator.SetBool(IsDeadHash, true);
        yield return new WaitForSeconds(2f);
        Destroy(padre);
        gene.enemigosContados = gene.enemigosContados - 1;
    }
    IEnumerator InicioSaltarin()
    {
        _animateWhenRun = false;
        seguidor.moverse = false;
        _animator.SetBool(MovingHash, false);
        _animator.SetBool(JumpHash, true);
        yield return new WaitForSeconds(1f);
        _animator.SetBool(MovingHash, true);
        seguidor.moverse = true;
        _animateWhenRun = true;
        gene.enemigosContados = gene.enemigosContados + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.tag=="Katanazo")
        {
            
            
            if (life > 0)
            {
                life = life - 100;
                StartCoroutine(RecibirGolpeVivo());
            }
            else
            {
                StartCoroutine(UltimoAliento());
            }
            
        }



    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "RashoLaser")
        {
            elapsed += Time.deltaTime;
            if (elapsed >= delay)
            {
                life = life - 10;
                if (life > 0)
                {
                    
                    StartCoroutine(RecibirGolpeVivo());
                    elapsed = 0;
                }
                else
                {
                    StartCoroutine(UltimoAlientoRasho());
                }

            }
            
        }
    }



    private void Update()
    {


        
            var tr = transform;
            var position = tr.position;
            float distancia = CalculateDistanceInSpace();

            if (distancia > DistanciaAtaque && _animateWhenRun)
            {
                
                _animator.SetBool(MovingHash, true);
                
            }
            else if(distancia <= DistanciaAtaque && _animateWhenRun)
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(AttackHash, true);

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
