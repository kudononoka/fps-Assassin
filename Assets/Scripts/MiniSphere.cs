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
   
    [Header("HP"), SerializeField] int hpmax;
    [Tooltip("現在のHP")] int nowhp;
    [Tooltip("GameManagerのpointに加算される")] int point = 10;
    [Tooltip("GameManagerのscoreに加算される")] int score = 10;
    
 
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _nav = GetComponent<NavMeshAgent>();
        _irradiation = transform.GetChild(3).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
     

        Vector3 target = _player.position - transform.position;
        Vector3 retarget = new Vector3(target.x, target.y + 0.9f, target.z);
        transform.rotation = Quaternion.LookRotation(retarget);
        float rot = transform.localEulerAngles.x;
        float distance = Vector3.Distance(transform.position, _player.position);

        if (distance < 10 && Mathf.Abs(target.x) > 4  && Mathf.Abs(target.y) > 4 )
        {
            _nav.SetDestination(transform.position);
            Debug.Log(_attackTimer);
            _attackTimer += Time.deltaTime;
            if (_attackTimer > _playAttackIrr)
            {
                _irradiation.Play();
                _attackTimer = 0;
            }
        }
        else if (distance >= 10)
        {
            _nav.SetDestination(_player.position);
            if(distance < 15)
            {
                _attackTimer += Time.deltaTime;
                if (_attackTimer > _playAttackIrr)
                {
                    _irradiation.Play();
                    _attackTimer = 0;
                }
            }
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


