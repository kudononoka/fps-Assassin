using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class EnemyTest : EnemyBase
{
    Rigidbody _rb;
    Animator _anim;
    NavMeshAgent _agent;
    NavMeshObstacle _obstacle;
    bool _targetPlayer = false;

    Transform _player;
    GameObject[] _core;
    Transform _target;

    float _attackTimer;
    [SerializeField] float _attackTime;
    bool isAttackParticle = false;

    [SerializeField] ParticleSystem _attackPartical;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _obstacle = GetComponent<NavMeshObstacle>();
        _obstacle.enabled = false;  
        //_player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _core = GameObject.FindGameObjectsWithTag("Core");
        Transform _targetCore = _core.OrderBy(target => Vector3.Distance(target.transform.position, transform.position)).First().GetComponent<Transform>();
        //_targetPlayer = false;
        _target = _targetCore;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(_target.position);
        //if (_targetPlayer)
        //{
        //    _agent.SetDestination(_player.position);
        //}
        //else
        //{
            _agent.SetDestination(_target.position);
        //}
        if(Vector3.Distance(_target.position, transform.position) < _agent.stoppingDistance)
        {
            _agent.enabled = false;
            _obstacle.enabled = true;
            Vector3 dir = _target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(dir);
        }
        if(_agent.velocity.magnitude <= 0)
        {
            //_attackTimer += Time.deltaTime;
            //if(_attackTimer > _attackTime)
            //{
            //    _anim.SetTrigger("Attack");
            //    _attackTimer = 0;
            //}
            
            
        }
        //TargetChange();

        _anim.SetFloat("Walk", _agent.velocity.magnitude);

        //if(isAttackParticle)
        //{
        //    _attackPartical.Play();
        //}
        //else
        //{
        //    _attackPartical.Stop();
        //}
    }

    //void TargetChange()
    //{
    //    if(isHit)
    //    {
    //        _targetPlayer = true;
    //        Vector3 dis = transform.position - _player.position;
    //        if(dis.magnitude >= 100)
    //        {
    //            isHit = false;
    //        }
    //    }
    //    else
    //    {
    //        _targetPlayer = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Core"))
        {
            _attackPartical.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Core"))
        {
            _attackPartical.Stop(true);
        }
    }
}
