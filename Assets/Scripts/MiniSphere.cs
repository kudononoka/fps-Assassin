using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniSphere : MonoBehaviour
{
    private Animator _anim;
    private Transform _player;
    private NavMeshAgent _nav;
    private ParticleSystem _irradiation;
    private float _playAttackIrr = 4;
    private float _attackTimer = 0;
    [SerializeField] EnemyIntrusionCollider _IntrusionCollider;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _nav = GetComponent<NavMeshAgent>();
        _irradiation = GameObject.Find("Irradiation").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = _player.position - transform.position;
        Vector3 retarget = new Vector3(target.x, target.y + 0.35f, target.z);
        transform.rotation = Quaternion.LookRotation(retarget);
        float rot = transform.localEulerAngles.x;
        

        Debug.Log(_player);
        if (_IntrusionCollider.IsIntrusion)
        {
            _nav.SetDestination(transform.position);
            _attackTimer += Time.deltaTime;
            if (_attackTimer > _playAttackIrr)
            {
                _irradiation.Play();
                _attackTimer = 0;
            }
            else if (_attackTimer < _playAttackIrr - 1)
            {
                
                transform.RotateAround(_player.position, Vector3.up, 0.1f + Time.deltaTime);
            }
        }
        else if (!_IntrusionCollider.IsIntrusion)
        {
            _nav.SetDestination(_player.position);
        }
        else
        {
            _nav.SetDestination(transform.position);
        }
       
    }
}
