using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] int _score = 0;
  
    [SerializeField] int _point = 0;
    [SerializeField] GameObject _ok;
    [SerializeField] GameObject _sellCanvas;
    [SerializeField] GameObject _normalCanvas;
    [SerializeField] Text SellCanvasPointText;
    [SerializeField] Text MainCanvasPointText;
    [SerializeField] Text MainCanvasScoreText;
    [SerializeField] Text TimerText;
    [SerializeField] int damageNumber = 0;
    private int _stageCount = 0; public int StageCount => _stageCount;

    private float _timer = 0;
    private float _battleTime = 30;
    private float _breakTime = 15;
    bool isBreak;
   
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
        if (_timer > _breakTime && isBreak)
        {
            _normalCanvas.SetActive(true);
            _sellCanvas.SetActive(false);
            _timer = 0;
            isBreak = !isBreak;
        }
        if (_timer > _battleTime && !isBreak)
        {
            _normalCanvas.SetActive(false);
            _sellCanvas.SetActive(true);
            _timer = 0;
            _stageCount++;
            isBreak = !isBreak;
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
}
