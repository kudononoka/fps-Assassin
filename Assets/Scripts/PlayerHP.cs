using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [Header("PlayerのHP"), SerializeField]
    int _hpmax;
    int _nowhp;
    Slider _hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage(int damage)
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
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Laser"))
        {
            Damage(1);
        }
    }
}
