using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
   
    [SerializeField,Header("残りの弾丸数")]int bulletNum;
    [SerializeField, Header("弾丸数MAX")] int bulletNumMAX;
    [SerializeField] Text bulletNumText;
    PlayerMove _player;

    public int BulletNum { get => bulletNum; }
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerMove>();
        bulletNum = bulletNumMAX;
        bulletNumText.text = $"{bulletNum} / {bulletNumMAX}";
    }

    // Update is called once per frame
    public void OnShoot()
    {
        
        bulletNum--;
        Debug.Log(bulletNum);
        bulletNumText.text = $"{bulletNum} / {bulletNumMAX}";
    }

    public void OnReload()
    {
        bulletNum = bulletNumMAX;
        bulletNumText.text = $"{bulletNum} / {bulletNumMAX}";
    }
}
