using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : ItemBase
{
    [Header("弾丸パワーアップ費用"), SerializeField]
    int _cost;
    int damage = 1; public int DamageNum => damage;
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
        if (GameManager.point > 0)
        {
            FindObjectOfType<GameManager>().CostPoint(_cost);
            damage += 2;
        }
    }
}
