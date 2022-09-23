using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PunchRobo : EnemyDamage
{
    private Animator _anim;
    private Transform _player;
    private NavMeshAgent _nav;
    
    
    
    private float attackTimer;
    private float attackPlayTime = 5;
    
    
    

    [Header("HP"), SerializeField] int hpmax;
    [Tooltip("現在のHP")] int nowhp;
    [Tooltip("GameManagerのpointに加算される")] int point = 50;
    [Tooltip("GameManagerのscoreに加算される")] int score = 25;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _nav = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, _player.position);
        
        if(distance < 1.5)
        {
            _nav.SetDestination(transform.position);
            attackTimer += Time.deltaTime;
            if(attackTimer > attackPlayTime)
            {
                _anim.SetTrigger("attack");
                attackTimer = 0;    
            }
        }
        if (distance < 15)
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
