using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntrusionCollider : MonoBehaviour
{
    private bool isIntrusion; 
    public bool IsIntrusion {  get { return isIntrusion; }  }

    
    // Start is called before the first frame update
    void Start()
    {
        isIntrusion = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isIntrusion = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            isIntrusion = false;
        }
    }
}
