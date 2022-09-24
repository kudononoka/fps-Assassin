using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDamage : MonoBehaviour
{
    int damage = 1; 
    public abstract void Point();
    private BulletPowerUp powerUp;
    public abstract void Score();
    ParticleSystem dead;
    ParticleSystem dead2;
    AudioSource audio;

    private void OnEnable()
    {
        powerUp = GameObject.Find("Item").GetComponent<BulletPowerUp>();
        damage = powerUp.DamageNum;
        dead = transform.GetChild(1).GetComponent<ParticleSystem>();
        dead2 = transform.GetChild(2).GetComponent<ParticleSystem>();
        audio = transform.GetChild(1).GetComponent<AudioSource>();
    }
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
       
        Score();
        hp -= damage;
        if (hp <= 0)
        {
            Point();
            GameManager.EnemyNum++;
            StartCoroutine(Dead());
        }
        
        return hp;
    }

    IEnumerator Dead()
    {
        audio.Play();
        dead.Play();
        dead2.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
   
}
