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
    [Header("着弾した時のパーティカル"), SerializeField] ParticleSystem endPartical;
    
    // Start is called before the first frame update


   

    private void OnEnable()
    {
        _sphere = GameObject.Find("Sphere");
        _camera = GameObject.Find("Main Camera");
    }


    void Start()
    {
        _camera = GameObject.Find("Main Camera");
        
       // vec2 = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    // Update is called once per frame
    void Update()
    {
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        
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
        if (gameObject != null)
        {
            Destroy(gameObject, 1.5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            endPartical.Play();
            Destroy(this.gameObject);
        }
    }


}
