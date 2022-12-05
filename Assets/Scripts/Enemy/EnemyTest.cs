using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTest : EnemyBase
{
    Rigidbody _rb;

    NavMeshAgent _agent;

    bool _targetPlayer;

    Transform _player;
    Transform _core;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _core = GameObject.FindWithTag("Core").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetPlayer)
        {
            _agent.SetDestination(_player.position);
        }
        else
        {
            _agent.SetDestination(_core.position);
        }

        TargetChange();
    }

    void TargetChange()
    {
        if(isHit)
        {
            _targetPlayer = true;
            Vector3 dis = transform.position - _player.position;
            if(dis.magnitude >= 100)
            {
                isHit = false;
            }
        }
        else
        {
            _targetPlayer = false;
        }
    }
}
