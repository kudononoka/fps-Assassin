using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControle : MonoBehaviour
{
    [Header("銃弾"),SerializeField]
    private GameObject _bulletPrefab;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetButton("Shoot"))
        {
            Debug.Log("bullet");
            time += Time.deltaTime;
            if (time > 0.1)
            {
                Instantiate(_bulletPrefab, gameObject.transform.position,gameObject.transform.rotation);
                time = 0;
            }
            //StartCoroutine("BulletGeneration");
        }
    }

    /*IEnumerable BulletGeneration()
    {
        for (int i = 0; i < 100; i++)
        {
            
            Instantiate(_bulletPrefab,gameObject.transform.position,Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }*/
}
