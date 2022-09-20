using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstate : MonoBehaviour
{
    [SerializeField] GameObject MiniSphere;
    [SerializeField] GameObject PunchRobo;
    float Timer;
    float InstateTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer+= Time.deltaTime;
        if(Timer > InstateTime)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(MiniSphere, transform.position, Quaternion.identity);
            }
            for (int i = 0; i < 2; i++)
            {
                Instantiate(PunchRobo, transform.position, Quaternion.identity);
            }
            Timer = 0;
        }
    }

    IEnumerator Instate()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            for (int i = 0; i < 3; i++)
            {
                Instantiate(MiniSphere, transform.position, Quaternion.identity);
            }
            for (int i = 0; i < 2; i++)
            {
                Instantiate(PunchRobo, transform.position, Quaternion.identity);
            }
        }
    }
}
