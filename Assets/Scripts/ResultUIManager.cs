using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField] Text RankText;
    [SerializeField] Text ScoreText;
    string rank = "C";
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
        
        if(killNum < 80 && playerDamageNum < 3000 && score > 0)
        {
            rank = "C";
        }
        if (killNum < 100 && playerDamageNum < 800 && score > 3000)
        {
            rank = "B";
        }
        if (killNum < 120 && playerDamageNum < 500 && score > 4000)
        {
            rank = "A";
        }
        if (killNum > 120 && playerDamageNum < 300 && score > 5000)
        {
            rank = "S";
        }

        return rank;
       
    }
}
