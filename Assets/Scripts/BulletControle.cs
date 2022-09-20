using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControle : MonoBehaviour
{
    [Header("銃弾"), SerializeField]
    private GameObject _bulletPrefab;
    private AudioSource _bulletClip;
   
    
    

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
    


    // Update is called once per frame
    void FixedUpdate()
    {
        
    }



    
}
