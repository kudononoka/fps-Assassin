using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [Header("PlayerのMaxHP"), SerializeField]float _hpmax;
    float _nowhp;
    [Header("PlayerのHPSlider"), SerializeField] Slider _hpSlider;

    [Tooltip("PunchRoboからのダメージ数")] int _punchRoboDamage = 5;
    [Tooltip("Bombからのダメージ数")] int _bombDamage = 10;
    [Tooltip("MiniSphereのレーザーのダメージ数")] float _laserDamage = 0.05f;
    [Tooltip("敵からダメージを受けた回数　ランクに使用")]int damageNum; public int DamageNum => damageNum;

    // Start is called before the first frame update
    void Start()
    {
        _hpSlider.maxValue = _hpmax;
        _nowhp = _hpmax;
        damageNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage(float damage)
    {
        _nowhp -= damage;
        if(_nowhp <= 0)
        {
            FindObjectOfType<GameManager>().IsGame = false;
        }
        else if (_nowhp > 0)
        {
            _hpSlider.value = _nowhp;
        }
        damageNum++;
    }

    public void Recovery(int recoveryAmount)
    {
        _nowhp += recoveryAmount;
        _hpSlider.value = _nowhp;
    }

    public void LaserCollisionEnter()
    {
        Damage(_laserDamage);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PunchRobo"))
        {
            Damage(_punchRoboDamage);
        }
        if(other.gameObject.CompareTag("Bomb"))
        {
            Damage(_bombDamage);
        }
    }


}
