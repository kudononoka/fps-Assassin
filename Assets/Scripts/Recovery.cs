using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : ItemBase
{
    [Header("回復薬費用"), SerializeField]
    int _cost;
    [Header("回復量"), SerializeField]
    int recoveryAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CostPoint()
    {
        if (GameManager.point >= _cost)
        {
            FindObjectOfType<GameManager>().CostPoint(_cost);
            FindObjectOfType<PlayerHP>().Recovery(recoveryAmount);
        }
    }
}
