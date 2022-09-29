using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    float _speed = 1000;
    
    GameObject _camera;
    Quaternion _forward;
    
    GameObject _sphere;
    ParticleSystem endPartical;
  
    private void　Awake()
    {
        _sphere = GameObject.Find("Sphere");
        _camera = GameObject.Find("Main Camera");
        endPartical = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    void Start()
    {
        _camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        
        if( _sphere.transform.position == Vector3.zero) //Rayが当たっていないときシーンの真ん中らへんにに行くように設定
        {
            _forward = Quaternion.AngleAxis(_camera.transform.eulerAngles.y, Vector3.up);
            transform.rotation = _forward * Quaternion.AngleAxis(_camera.transform.eulerAngles.x, Vector3.right);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _sphere.transform.position, _speed * Time.deltaTime);
        }

        if(gameObject != null)　//他のオブジェクトに当たらなかった場合自動的に破壊
        {
            Destroy(gameObject, 0.2f);
        }
    }

    
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(ParticleTime());
        }

    }

    IEnumerator ParticleTime()
    {
        endPartical.Play();
        yield return new WaitForSeconds(0.25f);
        Destroy(this.gameObject);
    }

}
