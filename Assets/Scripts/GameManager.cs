using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] int _score = 0; public static int score { get; }
    [SerializeField] int _point = 0;
    int damageNumber; public static int damageNum { get; }
    private static int enemyNumber; public static int EnemyNum { get { return enemyNumber; } set { enemyNumber = value; } }
    [SerializeField] GameObject[] _enemies;
    [Header("出現範囲"), SerializeField] float movingRange;

    [SerializeField] GameObject _sellCanvas;
    [SerializeField] GameObject _normalCanvas;
    [SerializeField] Text SellCanvasPointText;
    [SerializeField] Text MainCanvasPointText;
    [SerializeField] Text MainCanvasScoreText;
    [SerializeField] Text TimerText;
    [SerializeField] Text StageCountText;
    [SerializeField] PlayerHP playerHp;

    [Tooltip("Stageが変わるごとにPlayerの位置を初期化する")]
    Transform player;

    
    private int _stageCount = 0; public int StageCount => _stageCount;

    private float _timer = 0;
    [Header("戦闘時間"), SerializeField] float _battleTime = 60;
    [Header("休憩時間"), SerializeField] float _breakTime = 15;
    bool isBreak; public bool IsBreak => isBreak;
   
    bool isGame; public bool IsGame { get { return isGame; } set { isGame = value; } }

    public static GameManager Instance　=> instance;

    
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this as GameManager;
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
        EnemyInstate();
        _normalCanvas.SetActive(true);
        _sellCanvas.SetActive(false);
        isGame = true;
        _point = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        SellCanvasPointText.text = $"{_point}";
        MainCanvasPointText.text = $"{_point}";
        MainCanvasScoreText.text = $"{_score}";
        TimerText.text = String.Format("{0:00}", (int)_timer);
        StageCountText.text = $"{_stageCount}";
        if (_timer > _breakTime && isBreak)
        {
            EnemyInstate();
            player.position = Vector3.zero;
            _normalCanvas.SetActive(true);
            _sellCanvas.SetActive(false);
            _timer = 0;
            isBreak = !isBreak;
        }
        if (_timer > _battleTime && !isBreak && _stageCount < 3)
        {
            GameObjectFind("Enemy");
            GameObjectFind("Bomb");
            _normalCanvas.SetActive(false);
            _sellCanvas.SetActive(true);
            _timer = 0;
            _stageCount++;
            isBreak = !isBreak;
        }
        damageNumber = playerHp.DamageNum;
        if(_stageCount == 3 && !isBreak)
        {
            IsGame = false;
        }


        damageNumber = playerHp.DamageNum;
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
    
    

    void GameObjectFind(string name)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(name);
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                return;
            }
            Destroy(enemy);
        }
    }

    void EnemyInstate()
    {
        foreach (var enemy in _enemies)
        {
           
            if (enemy.name == "MiniSphere" || enemy.name == "PunchRobo (1)")
            {
                int num = UnityEngine.Random.Range(5, 7);
                for (int i = 0; i < num; i++)
                {
                    Vector3 position = new Vector3(UnityEngine.Random.Range(-movingRange, movingRange), 0, UnityEngine.Random.Range(-movingRange, movingRange));
                    Instantiate(enemy, position, Quaternion.identity);
                }
            }
            else if(enemy.name == "robotSphere")
            {
                Vector3 position = new Vector3(UnityEngine.Random.Range(-movingRange, movingRange), 0, UnityEngine.Random.Range(-movingRange, movingRange));
                Instantiate(enemy, position, Quaternion.identity);
            }
        }
    }
}
