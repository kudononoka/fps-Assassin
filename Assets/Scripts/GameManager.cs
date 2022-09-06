using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private int _score = 0;
　　private float Time = 0;
    


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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
