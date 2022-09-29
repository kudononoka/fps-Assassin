using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private static int _score = 0; public static int score { get { return _score; } }
    [SerializeField] private static int _point = 0; public static int point { get { return _point; } }
    private static int damageNumber = 0; public static int damageNum { get { return damageNumber; } }
    private static int enemyNumber = 0; public static int EnemyNum { get { return enemyNumber; } set { enemyNumber = value; } }
    [SerializeField] GameObject[] _enemies;
    [Header("出現範囲"), SerializeField] float movingRange;
    [Header("出現範囲"), SerializeField] float movingRange2;

    [SerializeField] GameObject _sellCanvas;
    [SerializeField] GameObject _normalCanvas;
    [SerializeField] Text SellCanvasPointText;
    [SerializeField] Text MainCanvasPointText;
    [SerializeField] Text MainCanvasScoreText;
    [SerializeField] Text TimerText;
    [SerializeField] Text StageCountText;
    [SerializeField] PlayerHP playerHp;

    [Tooltip("Stageが変わるごとに生き残っている敵の数を数える")] int SurvivingEnemies = 0;

    [Tooltip("Stageが変わるごとにPlayerの位置を初期化する")] Transform player;

    private int _stageCount = 1; public int StageCount => _stageCount;

    private float _timer = 0;
    [Header("戦闘時間"), SerializeField] float _battleTime = 60;
    [Header("休憩時間"), SerializeField] float _breakTime = 15;
    [Tooltip("休憩")]bool isBreak; public bool IsBreak => isBreak;
   
    bool isGame; public bool IsGame { get { return isGame; } set { isGame = value; } }

    public static GameManager Instance　=> instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance == this)
        {
            return;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();

        EnemyInstate(); //敵の生成

        _normalCanvas.SetActive(true);
        _sellCanvas.SetActive(false);

        isGame = true;
       
        _timer = _battleTime;

        _score = 0;
        _point = 0;
        SurvivingEnemies = 0;
        damageNumber = 0;
        enemyNumber = 0;
        _stageCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        SellCanvasPointText.text = $"Point {_point}";
        MainCanvasPointText.text = $"Point {_point}";
        MainCanvasScoreText.text = $"Score {_score}";
        TimerText.text = String.Format("{0:00}", (int)_timer);
        StageCountText.text = $"{_stageCount}";

        if (_timer <= 0 && isBreak)
        {
            EnemyInstate();
            player.position = Vector3.zero;
            _normalCanvas.SetActive(true);
            _sellCanvas.SetActive(false);
            _timer = _battleTime;
            isBreak = !isBreak;
        }
        if (_timer <= 0 && !isBreak)
        {
            GameObjectFind("Enemy");
            GameObjectFind("Bomb");
           
            if(SurvivingEnemies == 0)
            {
                Score(500);
            }
            
            if (_stageCount == 3)
            {
                SceneManager.LoadScene("Result");
            }
            else
            {
                _timer = _breakTime;
                _normalCanvas.SetActive(false);
                _sellCanvas.SetActive(true);

                _stageCount++;
                isBreak = !isBreak;
            }
        }
        damageNumber = playerHp.DamageNum;
        
        if(!isGame)
        {
            SceneManager.LoadScene("Result");
        }
        
    }

    public void Point(int point)
    {
        _point += point;
    }
    public void CostPoint(int costpoint)
    {
        _point -= costpoint;
    }

    public void Score(int score)
    {
        _score += score;
    }
    
    /// <summary>Stageが終わるごとに敵を破壊</summary>
    /// <param name="name">敵のタグ名</param>
    void GameObjectFind(string name)　
    {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(name);
            foreach (GameObject enemy in enemies)
            {
                if (enemy == null)
                {
                    return;
                }
                SurvivingEnemies++;
                Destroy(enemy);
            }   
    }

    /// <summary>Stageが変わるごとに敵を生成</summary>
    void EnemyInstate()
    {
        foreach (var enemy in _enemies)
        {
           
            if (enemy.name == "MiniPphereParticle" || enemy.name == "PunchRoboParticle")
            {
                int num = UnityEngine.Random.Range(10, 15);
                for (int i = 0; i < num; i++)
                {
                    Vector3 position = new Vector3(UnityEngine.Random.Range(-movingRange, movingRange), 0, UnityEngine.Random.Range(-movingRange, movingRange));
                    Vector3 PerfectPos = RangeSareti(position);
                    Instantiate(enemy, PerfectPos, Quaternion.identity);
                }
            }
            else if(enemy.name == "BigSphereParticle")
            {
                Vector3 position = new Vector3(UnityEngine.Random.Range(-movingRange, movingRange), 0, UnityEngine.Random.Range(-movingRange, movingRange));
                Instantiate(enemy, position, Quaternion.identity);
            }
        }
    }

    /// <summary>敵を生成するときPlayerと近すぎないように生成場所を設定する  Playerと生成場所の距離が20以上になるまでwhile文をまわす</summary>
    /// <param name="pos">敵の生成場所</param>
    
    private Vector3 RangeSareti(Vector3 pos)
    {
        while(Vector3.Distance(player.position, pos) < 20)
        {
            pos = new Vector3(UnityEngine.Random.Range(-movingRange, movingRange), 0, UnityEngine.Random.Range(-movingRange, movingRange));
        }
        return pos;
    }
}
