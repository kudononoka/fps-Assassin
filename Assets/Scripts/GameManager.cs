using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] int _score = 0;
    private float Time = 0;
    [SerializeField] int _point = 0;
    [SerializeField] Text pointText;
    [SerializeField] int damageNumber = 0;
    int bulletPower = 1; public int BulletPwer { get { return bulletPower; } set { bulletPower = value; } }
    bool isGame; public bool IsGame { get { return isGame; } set { isGame = value; } }

    public static GameManager Instance　=> instance;

    
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this as GameManager;
        }
        else if(instance == this)
        {
            return;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }
    void Start()
    {
        _point = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = $"{_point}";
    }

    public void Point(int point)
    {
        _point += point;
    }
    public void CostPoint(int costpoint)
    {
        _point -= costpoint;
    }

    public void Score(int score)
    {
        _score += score;
    }
}
