using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [Header("PlayerのMaxHP"), SerializeField]
    float _hpmax;
    float _nowhp;
    [Header("PlayerのHPSlider"), SerializeField] Slider _hpSlider;
    int damageNum; public int DamageNum => damageNum;

    // Start is called before the first frame update
    void Start()
    {
        _hpSlider.maxValue = _hpmax;
        _nowhp = _hpmax;
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
    }

    public void LaserCollisionEnter()
    {
        Damage(0.05f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PunchRobo"))
        {
            Damage(5);
        }
        if(other.gameObject.CompareTag("Bomb"))
        {
            Damage(10);
        }
    }


}
