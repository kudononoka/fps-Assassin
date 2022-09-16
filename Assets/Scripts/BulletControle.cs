using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControle : MonoBehaviour
{
    [Header("銃弾"), SerializeField]
    private GameObject _bulletPrefab;
    private AudioSource _bulletClip;
   //[SerializeField] PlayerController _playerController;
    private float time;
    /*private float distance = 100;
    private Vector2 vec2;
    private LayerMask layerMask = 0;*/
    

    // Start is called before the first frame update
    void Start()
    {
        _bulletClip = GetComponent<AudioSource>();
       
        //vec2 = new Vector2(Screen.width / 2, Screen.height / 2);
    }
    private void Update()
    {
       
            if (Input.GetButtonDown("Shoot"))
            {
                _bulletClip.Play();
                Instantiate(_bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
                //StartCoroutine("BulletGeneration");
            }
        
        /*Ray ray = Camera.main.ScreenPointToRay(vec2);
        RaycastHit hit;
        vec = ray.direction;
        if (Physics.Raycast(ray, out hit, distance, layerMask, QueryTriggerInteraction.Collide))
        {
            Debug.Log(hit.point);
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1f);
        transform.localRotation = Quaternion.LookRotation(hit.point);*/
        //Vector3 q = transform.TransformPoint(transform.rotation.x,transform.rotation.y,transform.rotation.z);
        //transform.rotation = Quaternion.Euler(q.x, q.y, q.z);
    }
    


    // Update is called once per frame
    void FixedUpdate()
    {
        
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
