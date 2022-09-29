using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiate : MonoBehaviour
{
    [Header("銃弾"), SerializeField]GameObject _bulletPrefab;
    AudioSource _bulletClip;
   
    // Start is called before the first frame update
    void Start()
    {
        _bulletClip = GetComponent<AudioSource>();
       
        
    }
    private void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            _bulletClip.Play();
            Instantiate(_bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
              
        }       
    }
}
