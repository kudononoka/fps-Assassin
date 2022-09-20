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
    }

    public void LaserCollisionEnter()
    {
        Damage(0.05f);
    }
    private void OnCollisionEnter(Collision other)
    {
        
    }

    
}
