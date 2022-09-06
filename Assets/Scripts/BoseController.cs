using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoseController : EnemyDamage
{
    private Animator _anim;
    private Rigidbody _rb;
    private Transform _player;
    private NavMeshAgent _agent;
    [SerializeField] GameObject bombPrefab;
    private Vector3 BombPos;
    private bool isAwake;
    private bool isStop;
    private float _rollSpeed = 60;
    private float playerDistance;
    private bool isrun = false;
    private Vector3 pos;
    private int moveSelect;
    private float attackPlayTime = 3;
    private float Timer;
    private bool isAttack;
    private int Count = 0;
    private int Count2 = 0;
    float distanceX;
    float distanceY;

    private float speed = 10f;
    private float gravity = 9.8f;
    private float _Velocity_0 = 1000;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GameObject.Find("robotSphere").GetComponent<Animator>();
        _rb = GameObject.Find("robotSphere").GetComponent<Rigidbody>();
        _agent = GameObject.Find("robotSphere").GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        BombPos = GameObject.Find("BombPos").GetComponent<Transform>().position;
        isAwake = false;
    }


    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(_player.position);

        _anim.SetTrigger("Bomb");
        
        if (Count == 0 && Timer > 1.5)
        {
            for (int i = 0; i < 3; i++)
            {
                
                Instantiate(bombPrefab, BombPos, Quaternion.identity);
            }
            Count++;
        }
        //isAttack = true;

        //_anim.SetBool("close",true);
        //playerDistance = Vector3.Distance(_player.position, transform.position);

        //float _speed = playerDistance / 1.15f * Time.deltaTime;
        //_rb.velocity = new Vector3(0, 0, _speed);

        /* playerDistance = Vector3.Distance(_player.position, transform.position);
         float velo =2 * playerDistance / 9.8f;
             float velo1 = 120 - 9.8f * velo;
             float velo2 = playerDistance / velo;
             Vector3 velo3 = new Vector3(0, velo1, velo2);
             transform.Translate(velo3 * Time.deltaTime);*/

        /* float L = Vector2.Distance(transform.position, _player.position);

         float velo = Mathf.Sqrt( L * gravity / 2 * Mathf.Sin(60) * Mathf.Cos(60));
         float veloz = velo * Mathf.Cos(60);
         float veloy = velo * Mathf.Sin(60);
         _rb.velocity = new Vector3( 0, veloy, veloz);*/
        if (isAttack)
        {
            playerDistance = Vector3.Distance(_player.position, transform.position);

            _anim.SetBool("close", true);

            if (playerDistance < 1)
            {
                _anim.SetBool("close", false);
                _agent.SetDestination(transform.position);
            }
            else
            {
                _agent.SetDestination(_player.position);
                _rb.AddTorque(0, 1300, 0);
            }
        }

       
        Debug.Log(Timer);

        if (isAttack)
        {
            _anim.SetTrigger("rollattack");
            _anim.SetBool("rollPlay", true);
            if (Count == 0)
            {

                Vector3 playerPos = new Vector3(_player.position.x + 20, _player.position.y, _player.position.z - 20);

                transform.position = Vector3.MoveTowards(transform.position, playerPos, 20 * Time.deltaTime);
                if (transform.position == playerPos)
                {
                    Count++;
                }
            }
            else if (Count == 1)
            {
                Vector3 playerPos = new Vector3(_player.position.x - 20, _player.position.y, _player.position.z + 20);

                transform.position = Vector3.MoveTowards(transform.position, playerPos, 20 * Time.deltaTime);
                if (transform.position == playerPos)
                {
                    _anim.SetBool("rollPlay", false);
                    isAttack = false;
                    Count--;
                    Timer = 0;
                }
            }
        }
    }
    
    

　　/*IEnumerator RollAttack()
    {
        if (Count == 0)
        {
            distanceX = +20;
            distanceY = -20;
        }
        else if(Count == 1)
        {
            distanceX = -20;
            distanceY = +20;
        }

        Vector3 playerPos = new Vector3(_player.position.x + distanceX, _player.position.y, _player.position.z + distanceY);
        yield return new WaitForSeconds(2);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, 20 * Time.deltaTime);
        if (transform.position == playerPos)
        {
            _anim.SetBool("rollPlay", isAttack = false);
            Timer = 0;
            Count++;
        }
                //}
                /*else if (Count == 1)
                {

                    Vector3 playerPos = new Vector3(_player.position.x - 20, _player.position.y, _player.position.z + 20);
                    yield return new WaitForSeconds(2);
                    transform.position = Vector3.MoveTowards(transform.position, playerPos, 20 * Time.deltaTime);
                    if (transform.position == playerPos)
                    {
                        _anim.SetBool("rollPlay", isAttack = false);
                        Timer = 0;
                        Count--;
                    }
                }
            
        

        
        
        

        //StartCoroutine("RollAttack");

        transform.rotation = Quaternion.LookRotation(_player.position);
        //int rollAttackCount = Random.Range(2, 4);
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 3; i++)
        {
            Vector3 playerPos = new Vector3(_player.position.x + 5, _player.position.y, _player.position.z - 5);
            _agent.SetDestination(playerPos);
            yield return new WaitForSeconds(8);
            Debug.Log(i);
        }
        _anim.SetTrigger("rollstop");
        if(Timer > attackPlayTime)
        {
            yield return new WaitForSeconds(2f);
            Vector3 playerPos = new Vector3(_player.position.x + 5, _player.position.y, _player.position.z - 5);
            _agent.SetDestination(playerPos);
            _agent.SetDestination(transform.position);
            _anim.SetTrigger("rollstop");
            yield return Timer = 0;
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("open",true);
            isAwake = true;
        }
    }
}

