using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniSphere : EnemyBase, Interface
{
    Transform _player;
    NavMeshAgent _nav;
    ParticleSystem _laser;

    Vector3 target;
    Vector3 velocity;

    float _playAttack = 4;
    float _attackTimer = 0;

    [Header("HP"), SerializeField] int hpmax;
    [Tooltip("現在のHP")] int nowhp;
    [Tooltip("GameManagerのpointに加算される")] int point = 10;
    [Tooltip("GameManagerのscoreに加算される")] int score = 10;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _nav = GetComponent<NavMeshAgent>();
        _laser = transform.GetChild(1).GetComponent<ParticleSystem>();
        nowhp = hpmax;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = _player.position - transform.position;
        target = new Vector3(velocity.x, velocity.y + 0.9f, velocity.z); //向く方向の調整
        transform.rotation = Quaternion.LookRotation(target.normalized);
        float distance = Vector3.Distance(transform.position, _player.position);

        if (distance < 10 && Mathf.Abs(velocity.x) > 4 && Mathf.Abs(velocity.y) > 4) //プレイヤーの真上に来ないように設定
        {
            _nav.SetDestination(transform.position);
            LaserAttack();
        }
        else if (distance >= 10)
        {
            _nav.SetDestination(_player.position);
            if (distance < 15)
            {
                LaserAttack();
            }
        }
        else
        {
            _nav.SetDestination(transform.position);
        }
    }

    private void LaserAttack()
    {
        _attackTimer += Time.deltaTime;
        if (_attackTimer > _playAttack)
        {
            _laser.Play();
            _attackTimer = 0;
        }
    }

   
   
    public void EnemyDamage(int damage)
    {
        nowhp -= damage;
        if (nowhp <= 0)
        {
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


