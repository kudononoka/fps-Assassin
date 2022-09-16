using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniSphere : EnemyDamage
{
    private Animator _anim;
    private Transform _player;
    //private float _navStartTime = 4;
    private float Timer = 0;
    private NavMeshAgent _nav;
    private ParticleSystem _irradiation;
   
    private float _playAttackIrr = 4;
    private float _attackTimer = 0;
    [SerializeField] EnemyIntrusionCollider _IntrusionCollider;
    [Header("HP"), SerializeField] int hpmax;
    [Tooltip("現在のHP")] int nowhp;
    [Tooltip("GameManagerのpointに加算される")] int point = 10;
    [Tooltip("GameManagerのscoreに加算される")] int score = 5;
    
 
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _nav = GetComponent<NavMeshAgent>();
        _irradiation = GameObject.Find("Irradiation").GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
     

        Vector3 target = _player.position - transform.position;
        Vector3 retarget = new Vector3(target.x, target.y + 0.9f, target.z);
        transform.rotation = Quaternion.LookRotation(retarget);
        float rot = transform.localEulerAngles.x;


        if (_IntrusionCollider.IsIntrusion )
        {
            _nav.SetDestination(transform.position);
            _attackTimer += Time.deltaTime;
            if (_attackTimer > _playAttackIrr)
            {
                _irradiation.Play();
                _attackTimer = 0;
            }
            else if (_attackTimer < _playAttackIrr - 1)
            {

                transform.RotateAround(_player.position, Vector3.up, 0.1f + Time.deltaTime);
            }
        }
        else if (!_IntrusionCollider.IsIntrusion )
        {
            _nav.SetDestination(_player.position);
        }
        else
        {
            _nav.SetDestination(transform.position);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit");
            nowhp = Damage(hpmax);
            hpmax = nowhp;
            
        }
    }

    public override void Point()
    {
        FindObjectOfType<GameManager>().Point(point);
    }
    public override void Score()
    {
        FindObjectOfType<GameManager>().Score(score);
    }
}


