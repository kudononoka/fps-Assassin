using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoseController : EnemyBase,Interface
{
    Animator _anim;
    NavMeshAgent _agent;

    [SerializeField] GameObject _bombPrefab;
    Transform _bombPos;
    int _bombCount = 0;

    [Header("移動範囲"), SerializeField] float _movingRange;
    
    [Header("HP"), SerializeField] int hpmax;
    [Tooltip("現在のHP")] int nowhp;
    [Tooltip("GameManagerのpointに加算される")] int point = 10;
    [Tooltip("GameManagerのscoreに加算される")] int score = 5;

    
    private void OnEnable()
    {
        _anim = transform.root.transform.GetChild(0).GetComponent<Animator>();
        _agent = transform.root.transform.GetChild(0).GetComponent<NavMeshAgent>();
        _bombPos = GameObject.Find("BombPos").GetComponent<Transform>();
        nowhp = hpmax;
    }


    // Update is called once per frame
    void Update()
    {
        _anim.SetFloat("rollattack", _agent.velocity.magnitude);

        
        if (!_agent.pathPending)//経路がない時
        {
            
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _agent.velocity = Vector3.zero;
                
                Vector3 randomPos = new Vector3(Random.Range(-_movingRange, _movingRange), 0, Random.Range(-_movingRange, _movingRange));
                if (Vector3.Distance(randomPos, transform.position) > 50)
                {
                    _agent.SetDestination(randomPos);
                }
               
            }
        }

        if (_bombCount == 0)
        {
            StartCoroutine(Bomb());
            _bombCount++;
        }
        

        IEnumerator Bomb()
        {
            _anim.SetTrigger("Bomb");
            yield return new WaitForSeconds(1.5f);
            Vector3 _bombpos = _bombPos.position;
            for (int i = 0; i < 2; i++)
            {
                Instantiate(_bombPrefab, _bombpos, Quaternion.identity);
            }

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

    
    

　　
    


