using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PunchRobo : EnemyDamage
{
    private Animator _anim;
    private Transform _player;
    private NavMeshAgent _nav;
    private Vector3 _pastPosition;
    private float speed = 5f;
    private bool attackstop;
    private float attackTimer;
    private float attackPlayTime = 4;
    private bool isAttack;
    private bool isRun = false;
    private int Count = 0;
    private Vector3 rotate;

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
        _pastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(transform.position, _player.position);
        Vector3 nowpos = transform.position;
        Vector3 velocity = (nowpos - _pastPosition) / Time.deltaTime;
        if (distance < 3)
        {
         
            StartCoroutine(Attack());
            Debug.Log("ぬけた！");
            if (isAttack && velocity.magnitude < 0.01)
            {
               _anim.SetBool("attack2",isAttack = false);
               Count = 0;
            }
        }  
        else if (distance < 30)
        {
            isRun = true;
            _nav.speed = 10;
            _nav.SetDestination(_player.position);
            
        }

        

        if (isRun)
        {
            _anim.SetTrigger("run");
            
        }
        _anim.SetFloat("runstart", velocity.magnitude);
        _pastPosition = nowpos;

        
    }
    
    IEnumerator Attack()
    {
        if(Count == 0)
        { 
            _anim.SetTrigger("attack");
            Count++;
        }
        yield return new WaitForSeconds(5);
        _nav.SetDestination(new Vector3(_player.position.x + 4,_player.position.y, _player.position.z + 4));
        yield return new WaitForSeconds(1f);
        _anim.SetBool("attack2",isAttack = true);
        yield return new WaitForSeconds(1);
        _nav.speed = 30;
        _nav.SetDestination(_player.position);
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
