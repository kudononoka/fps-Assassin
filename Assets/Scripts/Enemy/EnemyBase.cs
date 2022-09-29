using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>これはEnemyの基底クラスです</summary>
public abstract class EnemyBase : MonoBehaviour
{
    
    public abstract void Point();
    public abstract void Score();

    [Tooltip("死んだ時の爆発パーティカル")]ParticleSystem deadParticle;
    [Tooltip("死んだ時の爆発音")] AudioClip deadAudio;

    
    private void OnEnable()
    {
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

    
    protected void Damage()
    {
        Score();
        Point();
        GameManager.EnemyNum++;
        transform.root.position = transform.position;　//親オブジェクト(パーティカル、音)の位置を子オブジェクト位置に修正
        deadParticle.Play();
        transform.root.GetComponent<AudioSource>().PlayOneShot(deadAudio);　
        Destroy(gameObject);
    }

}
