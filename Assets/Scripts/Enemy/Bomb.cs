using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : EnemyBase
{
    Rigidbody _rb;
    Transform _player; 
    [Tooltip("爆発のダメージ用のコライダー")]SphereCollider _collider;
    NavMeshAgent _agent;
   
    private int _hp = 1;

    [Tooltip("GameManagerのpointに加算される")] int point = 10;
    [Tooltip("GameManagerのscoreに加算される")] int score = 5;
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _collider = GetComponent<SphereCollider>();
        _collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(_player.position);
        
        _agent.SetDestination(_player.position);
        

        if (Vector3.Distance(transform.position, _player.position) < 3)
        {
            _collider.enabled = true;
            Damage();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _collider.enabled = true; 
            Damage();
        }
    }

    //public override void Point()
    //{
    //    FindObjectOfType<GameManager>().Point(point);
    //}
    //public override void Score()
    //{
    //    FindObjectOfType<GameManager>().Score(score);
    //}
}
