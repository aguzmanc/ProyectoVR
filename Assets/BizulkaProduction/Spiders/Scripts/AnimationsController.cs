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
    public float velocidad;

    GameObject jugador;

  
    private float life=400;
    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Jugador");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "RashoLaser")
        {
            _animateWhenRun = false;
            life = life - 50;
            if (life > 0)
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(HitHash, true);
            }
            else
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(IsDeadHash, true);
            }
            _animateWhenRun = true;

        }
        else if (other.tag == "Espadazo")
        {
            _animateWhenRun = false;
            life = life - 100;
            if (life > 0)
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(HitHash, true);
            }
            else
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(IsDeadHash, true);
            }
            _animateWhenRun = true;
        }



    }

   

    private void Update()
    {
       

        if (_animateWhenRun)
        {
            var tr = transform;
            var position = tr.position;
            float distancia = CalculateDistanceInSpace();

            if (distancia>2.5f)
            {
                Vector3 posJugador = new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z);
                transform.LookAt(posJugador);

                transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad * Time.deltaTime);
                _animator.SetBool(MovingHash, true);
                //var dirrection = position - _lastPosition;
                //dirrection.y = 0;
                //_lastRotation = Quaternion.LookRotation(dirrection);
            }
            else
            {
                _animator.SetBool(MovingHash, false);
                _animator.SetBool(AttackHash, true);

            }
            
            //transform.rotation = Quaternion.Lerp(transform.rotation, _lastRotation, 10f * Time.deltaTime);
            //_lastPosition = position;
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