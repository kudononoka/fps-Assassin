using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDamage : MonoBehaviour
{
    private int damage = 1; public int enemyDamage { get { return damage; } set { damage = value; } }
    public abstract void Point();
    public abstract void Score();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    protected int Damage(int hp)
    {
        Debug.Log("ダメージ");
        Score();
        hp -= damage;
        if (hp <= 0)
        {
            Point();
            Destroy(gameObject);
           
        }
        
        return hp;
    }


   
}
