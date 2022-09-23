using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    private float _speed = 1000;
    //private LayerMask layerMask = 0;
    private GameObject _camera;
    private Quaternion _forward;
    // private float distance = 100;
    //private Vector2 vec2;
    // private Vector3 vec;*/
    private int gameObjectdamage;
    private GameObject _sphere;
     ParticleSystem endPartical;
    
    // Start is called before the first frame update


   

    private void OnEnable()
    {
        _sphere = GameObject.Find("Sphere");
        _camera = GameObject.Find("Main Camera");
        endPartical = transform.GetChild(0).GetComponent<ParticleSystem>();
    }


    void Start()
    {
        _camera = GameObject.Find("Main Camera");
        
       // vec2 = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
            
        
        if( _sphere.transform.position == Vector3.zero)
        {
            _forward = Quaternion.AngleAxis(_camera.transform.eulerAngles.y, Vector3.up);
            transform.rotation = _forward * Quaternion.AngleAxis(_camera.transform.eulerAngles.x, Vector3.right);
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _sphere.transform.position, _speed * Time.deltaTime);
        }
        if(gameObject != null)
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
