﻿using System.Collections;
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
    [Header("移動範囲"), SerializeField] float movingRange;
    private Transform BombPos;
   
    private float playerDistance;
    
    private int Count = 0;

    [Header("HP"), SerializeField] int hpmax;
    [Tooltip("現在のHP")] int nowhp;
    [Tooltip("GameManagerのpointに加算される")] int point = 10;
    [Tooltip("GameManagerのscoreに加算される")] int score = 5;

    /*private float speed = 10f;
    private float gravity = 9.8f;
    private float _Velocity_0 = 1000;*/
    // Start is called before the first frame update
    private void OnEnable()
    {
        _anim = transform.root.gameObject.GetComponent<Animator>();
        _rb = transform.root.gameObject.GetComponent<Rigidbody>();
        _agent = transform.root.gameObject.GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        BombPos = GameObject.Find("BombPos").GetComponent<Transform>();
    }
   

    // Update is called once per frame
    void Update()
    {
        _anim.SetFloat("rollattack", _agent.velocity.magnitude);

        /*if (Count == 0)
        {
            StartCoroutine(Bomb());
            Count++;
        }*/

        //if(Count == 1)
        //{
        if (!_agent.pathPending)
        {
            
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _agent.velocity = Vector3.zero;

                if (Count == 1)
                {
                    Count--;
                }

                Debug.Log("目的地についた");
                Vector3 randomPos = new Vector3(Random.Range(-movingRange, movingRange), 0, Random.Range(-movingRange, movingRange));
                if (Vector3.Distance(randomPos, transform.position) > 50)
                {
                    _agent.SetDestination(randomPos);
                }
               
            }
        }

        if (Count == 0)
        {
            StartCoroutine(Bomb());
            Count++;
        }
        //}
        //if(_agent.velocity.magnitude < 0.1)
        //{
         //   Count--;
        //}
        

        IEnumerator Bomb()
        {
            _anim.SetTrigger("Bomb");
            yield return new WaitForSeconds(1.5f);
            Vector3 _bombpos = BombPos.position;
            for (int i = 0; i < 2; i++)
            {
                Instantiate(bombPrefab, _bombpos, Quaternion.identity);
            }

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

    
    

　　
    


