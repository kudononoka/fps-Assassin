using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField] Text RankText;
    [SerializeField] Text ScoreText;

    private void Awake()
    {
        
        ScoreText.text = $"{String.Format("{0:000000}",GameManager.score)}";
    }
    // Start is called before the first frame update
    void Start()
    {
        RankText.text = $"{RankJudge(GameManager.EnemyNum, GameManager.damageNum, GameManager.score)}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string RankJudge(int killNum,int playerDamageNum,int score)
    {
        if(killNum < 15 && playerDamageNum > 20 && score < 100)
        {
            return "C";
        }
        if (killNum < 20 && playerDamageNum > 15 && score < 200)
        {
            return "B";
        }
        if (killNum < 25 && playerDamageNum > 10 && score < 400)
        {
            return "A";
        }
        if (killNum < 30 && playerDamageNum > 5 && score < 800)
        {
            return "S";
        }
        return "S";
    }
}
