using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    private float _speed = 200;
    private GameObject _camera;
    private Quaternion _forward;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        _forward = Quaternion.AngleAxis(_camera.transform.eulerAngles.y, Vector3.up);
        transform.rotation = _forward * Quaternion.AngleAxis(_camera.transform.eulerAngles.x, Vector3.right); ;
        transform.Translate(Vector3.forward  * Time.deltaTime * _speed);
        Destroy(gameObject,1.5f);
    }
}
