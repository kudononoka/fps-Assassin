using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPosition : MonoBehaviour
{
    public Vector3 _hitpoint;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _hitpoint = other.contacts[0].normal;
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _hitpoint = other.ClosestPoint(this.transform.position);
        }
    }*/
}
