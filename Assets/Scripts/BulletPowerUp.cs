using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : ItemBase
{
    [Header("弾丸パワーアップ費用"), SerializeField]
    int _cost;
    [Tooltip("Enemyに与えるダメージの変数を変えるため参照"), SerializeField] EnemyDamage _enemyDamage;
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
        FindObjectOfType<GameManager>().CostPoint(_cost);
        _enemyDamage.enemyDamage += 2;
    }
}
