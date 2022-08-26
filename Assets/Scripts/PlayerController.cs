using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    //[SerializeField] GameObject _looktarget;
    private Vector3 _look;
    private Rigidbody _rb;
    private Animator _anim;
    private Quaternion _forward;
    private Vector3 _right;
    private Quaternion _rotation;
    private Vector3 _gun;
    private GameObject _camera;
    private GameObject _cmSub;
    private Transform _subcameraTra;
    private Image _target;

    private float _walkSpeed = 5f;
    private bool isSet = false;
    
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _camera = GameObject.Find("Main Camera");
        
        _cmSub = GameObject.Find("CM vcam2");
        _cmSub.SetActive(false);
        
        //_gun = GameObject.Find("gunfrem").GetComponent<Transform>().localPosition;
        //_subcameraTra = GameObject.Find("CM vcam2").GetComponent<Transform>();
        _target = GameObject.Find("target").GetComponent<Image>();
        _target.enabled = false;
        //_subcamera.enabled = false;
    }
    private void Update()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");



        //_forward = Vector3.Scale( transform.TransformDirection(_camera.forward),new Vector3(0,0,1)).normalized;
        //_right = Vector3.Scale( transform.TransformDirection(_camera.right),new Vector3(1,0,0)).normalized;

        if (isSet == false)
        {
            _forward = Quaternion.AngleAxis(_camera.transform.eulerAngles.y, Vector3.up);

            _rb.velocity = _forward * new Vector3(x * _walkSpeed, 0, -z * _walkSpeed);
            float _rotateSpeed = 600 * Time.deltaTime;


            _rotation = Quaternion.LookRotation(_rb.velocity, Vector3.up);
            _anim.SetFloat("walk", _rb.velocity.magnitude);

            if (_rb.velocity.magnitude > 0.1)
            {
                if (Input.GetButton("Run"))
                {
                    _anim.SetBool("run", true);
                    _walkSpeed = 10f;
                }
                else
                {
                    _anim.SetBool("run", false);
                    _walkSpeed = 5f;
                }
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, _rotateSpeed);
        }



        if (Input.GetButton("Upfream"))
        {
            isSet = true;
            _cmSub.SetActive(true);
            _walkSpeed = 8;
            _rb.velocity = new Vector3(x * _walkSpeed, 0, -z * _walkSpeed);
            _forward = Quaternion.AngleAxis(_camera.transform.eulerAngles.y, Vector3.up) * Quaternion.Euler(0,10,0);
            transform.rotation = _forward;
            //_subcamera.enabled = true;
            _target.enabled = true;
            _anim.SetBool("set",true);
            
        }
        else
        {
            _walkSpeed = 5;
            _cmSub.SetActive(false);
            _anim.SetBool("set", false);
            _target.enabled = false;
            isSet = false;
            //_subcamera.enabled = false;
        }

        
    }

    
}
