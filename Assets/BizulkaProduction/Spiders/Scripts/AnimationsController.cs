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
    GameObject generador;
    GeneraradorMete gene;
    public float life;
    GameObject padre;
    float delay = 0.1f;
    float elapsed;
    float delay2 = 1f;
    float elapsed2;

    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;

    JugadorCompleto jugacomple;
    float dano;


    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        padre = gameObject.transform.parent.gameObject;
        jugador = GameObject.FindGameObjectWithTag("Jugador");
        seguidor = gameObject.GetComponentInParent<SeguidorDos>();
        generador = GameObject.FindGameObjectWithTag("Detector");
        gene = generador.GetComponentInParent<GeneraradorMete>();
        gene.enemigosContados = gene.enemigosContados +1;
        jugacomple = jugador.GetComponentInParent<JugadorCompleto>();

        if (gameObject.tag == "Aranabb")
        {
            life = 50;
            dano = 3;

        }
        else if (gameObject.tag == "AranaCafe")
        {
            life = 300;
            dano = 5;

        }
        else if (gameObject.tag == "AranaVerde")
        {
            life = 400;
            dano = 8;

        }
        else if (gameObject.tag == "AranaRoja")
        {
            life = 500;
            dano = 10;

        }
    }

    IEnumerator RecibirGolpeVivoRasho()
    {
        _animateWhenRun = false;
        seguidor.moverse = false;
        _animator.SetBool(MovingHash, false);
        _animator.SetBool(AttackHash, false);
        _animator.SetBool(HitHash, true);
        if (!controlAudio.isPlaying)
        {
            controlAudio.PlayOneShot(audios[3], 0.6f);
        }
        yield return new WaitForSeconds(2);
        _animator.SetBool(MovingHash, true);
        seguidor.moverse = true;
        _animateWhenRun = true;
    }

    IEnumerator RecibirGolpeVivo()
    {
        _animateWhenRun = false;
        seguidor.moverse = false;
        _animator.SetBool(MovingHash, false);
        _animator.SetBool(AttackHash, false);
        _animator.SetBool(HitHash, true);
        controlAudio.PlayOneShot(audios[3], 0.6f);
        controlAudio.PlayOneShot(audios[4], 1f);
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
        controlAudio.PlayOneShot(audios[2], 1f);
        yield return new WaitForSeconds(1f);
        Destroy(padre);
        gene.enemigosContados = gene.enemigosContados - 1;
        jugacomple.eliminaciones = jugacomple.eliminaciones + 1;
    }
    IEnumerator UltimoAlientoRasho()
    {
        _animateWhenRun = false;
        seguidor.moverse = false;
        _animator.SetBool(MovingHash, false);
        _animator.SetBool(IsDeadHash, true);
        if (!controlAudio.isPlaying)
        {
            controlAudio.PlayOneShot(audios[2], 1f);
        }
        yield return new WaitForSeconds(1f);
        Destroy(padre);
        gene.enemigosContados = gene.enemigosContados - 1;
        jugacomple.eliminaciones = jugacomple.eliminaciones + 1;
    }

    IEnumerator Final()
    {
        _animateWhenRun = false;
        seguidor.moverse = false;
        _animator.SetBool(MovingHash, false);
        _animator.SetBool(IsDeadHash, true);
        yield return new WaitForSeconds(1f);
        Destroy(padre);
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Katanazo")
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
        else if (other.tag=="Tesla")
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
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "RashoLaser")
        {
            elapsed += Time.deltaTime;
            if (elapsed >= delay)
            {
                life = life - 15;
                if (life > 0)
                {
                    
                    StartCoroutine(RecibirGolpeVivoRasho());
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

            if (jugacomple.eliminaciones >= 50 || jugacomple.vidaJugador <= 0)
            {
            StartCoroutine(Final());
            }


            var tr = transform;
            var position = tr.position;
            float distancia = CalculateDistanceInSpace();

            if (distancia > 2.5f && _animateWhenRun)
            {
                if (!controlAudio.isPlaying)
                {
                controlAudio.PlayOneShot(audios[0], 0.5f);
                }
                _animator.SetBool(MovingHash, true);

            }
            else if (distancia <= 2.5f && _animateWhenRun)
            {

                elapsed2 += Time.deltaTime;
                if (elapsed2 >= delay2)
                {
                jugacomple.estado = false;
                jugacomple.vidaJugador = jugacomple.vidaJugador - dano;
                elapsed2 = 0;


                }
            if (!controlAudio.isPlaying)
                {
                controlAudio.PlayOneShot(audios[1], 0.8f);
                }
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(AttackHash, true);
                

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