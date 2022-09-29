using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDamage : MonoBehaviour
{
    int damage = 1; 
    
    [Tooltip("現在の銃弾の攻撃力")]BulletPowerUp powerUp;
    public abstract void Point();
    public abstract void Score();

    [Tooltip("死んだ時の爆発パーティカル")]ParticleSystem deadParticle;
    [Tooltip("死んだ時の爆発音")] AudioClip deadAudio;
    
    private void OnEnable()
    {
        powerUp = GameObject.Find("Item").GetComponent<BulletPowerUp>();
        damage = powerUp.DamageNum;
        deadParticle = transform.root.gameObject.GetComponent<ParticleSystem>();
        deadAudio = transform.root.GetComponent<AudioSource>().clip;
    }
    private void Awake()
    {
        deadParticle = transform.root.gameObject.GetComponent<ParticleSystem>();
        deadAudio = transform.root.GetComponent<AudioSource>().clip;
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
            transform.root.position = transform.position;　//親オブジェクト(パーティカル、音)の位置を子オブジェクト位置に修正
            deadParticle.Play();
            transform.root.GetComponent<AudioSource>().PlayOneShot(deadAudio);　
            Destroy(gameObject);
        }
        
        return hp;
    }

   
}
