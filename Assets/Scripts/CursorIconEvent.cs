using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorIconEvent : MonoBehaviour
{
    private Image _itemIcon;
    // Start is called before the first frame update
    void Start()
    {
        _itemIcon = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Icon"))
        {
            Debug.Log("色が変わる");
            
        }
    }

    
}
