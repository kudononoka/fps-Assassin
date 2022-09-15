using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTarget : MonoBehaviour
{
    private bool isPlayer; public bool IsPlayer { get { return isPlayer; } set { isPlayer = value; } }
    // Start is called before the first frame update
    void Start()
    {
        isPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }
}
