using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PunchRobo : EnemyBase,Interface
{
    Animator _anim;
    Transform _player;
    NavMeshAgent _nav;
    
    float attackTimer;
    float attackPlayTime = 4;

    [Tooltip("近距離攻撃を開始する距離")] float punchDistance = 1.5f;
    [Tooltip("腕の回転攻撃を開始する距離")] float armAttackDistance = 15;

    [Header("HP"), SerializeField] int hpmax;
    [Tooltip("現在のHP")] int nowhp;

    [Tooltip("GameManagerのpointに加算される")] int point = 20;
    [Tooltip("GameManagerのscoreに加算される")] int score = 25;
    // Start is called before the first frame update
    void Awake()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _nav = GetComponent<NavMeshAgent>();
        nowhp = hpmax;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, _player.position);
        
        if(distance < punchDistance)
        {
            _nav.SetDestination(transform.position);
            attackTimer += Time.deltaTime;
            if(attackTimer > attackPlayTime)
            {
                _anim.SetTrigger("attack");
                attackTimer = 0;    
            }
        }
        if (distance < armAttackDistance)
        {
            _nav.SetDestination(_player.position);
            _anim.SetFloat("rotateattack", _nav.velocity.magnitude);
            
        }
        if (distance < 100)
        {
            _nav.SetDestination(_player.position);
        }
        else
        {
            _nav.SetDestination(transform.position);
        }
        _anim.SetFloat("runstart", _nav.velocity.magnitude);
    }


    public void EnemyDamage(int damage)
    {
        nowhp -= damage;
        if (nowhp <= 0)
        {
            Damage();
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
