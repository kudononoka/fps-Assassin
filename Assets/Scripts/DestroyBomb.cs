using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    private GameObject bomb;
    private Bomb _bombScript;
    // Start is called before the first frame update
    private void OnEnable()
    {
        bomb = transform.root.gameObject;
        _bombScript = bomb.GetComponent<Bomb>();
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            _bombScript.TriggerEnable();
        }
    }*/
}
