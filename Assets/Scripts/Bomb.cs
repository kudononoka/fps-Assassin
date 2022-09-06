using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _player; 
   
    private NavMeshAgent _agent;
   
    // Start is called before the first frame update
    void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player").GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(_player);
        Vector3 _playerPos = _player;
        _agent.SetDestination(_playerPos);
        

        if (Vector3.Distance(transform.position, _playerPos) < 3)
        {
            Destroy(gameObject);
        }
        
           
        
    }
}
