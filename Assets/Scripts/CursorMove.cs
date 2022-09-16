using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMove : MonoBehaviour
{
    [SerializeField] float _speed;
    private RectTransform rect;
    
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 pos = rect.anchoredPosition + new Vector2(-Input.GetAxisRaw("Horizontal") * _speed, -Input.GetAxisRaw("Vertical") * _speed);
        pos.x = Mathf.Clamp(pos.x, -Screen.width / 2, Screen.width / 2);
        pos.y = Mathf.Clamp(pos.y, -Screen.height / 2, Screen.height / 2);
        rect.anchoredPosition = pos;
    }

  
}
