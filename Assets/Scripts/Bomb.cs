using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : EnemyDamage
{
    private Rigidbody _rb;
    private Transform _player; 
    private SphereCollider _collider;
    private NavMeshAgent _agent;
    private SphereCollider _collision;

    ParticleSystem deadBomb;
    ParticleSystem dead2Bomb;

    [Tooltip("GameManagerのpointに加算される")] int point = 10;
    [Tooltip("GameManagerのscoreに加算される")] int score = 5;
    // Start is called before the first frame update
    void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _collider = GetComponent<SphereCollider>();
        _collider.enabled = false;
        
        deadBomb = transform.GetChild(1).GetComponent<ParticleSystem>();
        dead2Bomb = transform.GetChild(2).GetComponent<ParticleSystem>();

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(_player.position);
        
        _agent.SetDestination(_player.position);
        

        if (Vector3.Distance(transform.position, _player.position) < 3)
        {
            StartCoroutine(TriggerEnable());
            
        }
    }

    public IEnumerator TriggerEnable()
    {
        _collider.enabled = true;
        deadBomb.Play();
        dead2Bomb.Play();
       yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            StartCoroutine(TriggerEnable());
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
