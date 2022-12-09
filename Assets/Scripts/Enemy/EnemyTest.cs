using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class EnemyTest : EnemyBase
{
    Rigidbody _rb;

    NavMeshAgent _agent;

    bool _targetPlayer = false;

    Transform _player;
    GameObject[] _core;
    Transform _targetCore;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _core = GameObject.FindGameObjectsWithTag("Core");
        _targetCore = _core.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position)).First().GetComponent<Transform>();
        _targetPlayer = false;
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
            _agent.SetDestination(_targetCore.position);
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
