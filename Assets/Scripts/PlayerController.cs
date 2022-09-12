using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    /// <summary>重力</summary>
    private Rigidbody _rb;
    /// <summary>Playerのアニメーター</summary>
    private Animator _anim;
    [Tooltip("カメラの向きを取得")]
    private Quaternion _forward;
    [Tooltip("カメラの向きとプレイヤーの向きをそろえる")]
    private Quaternion _rotation;
  　/// <summary>MainCamera</summary>
    private GameObject _camera;
　　/// <summary>VirtualCamera 三人称視点</summary>
  　[Tooltip("移動などに使うカメラ")]
    private GameObject _cmSub;
    /// <summary> VirtualCamera 三人称視点　プレイヤー近くの背後の画面</summary>
    [Tooltip("射撃時のカメラ")]
    private GameObject _cmSubMain;
    /// <summary>照準UI</summary>
    private Image _target;
    private Image _normal;

    private int hp;
    private int maxHp = 100;
    private int minHp = 0;

    private float _moveSpeed = 5f;
    private float _walkSpeed = 5f;
    private float _runSpeed = 10f;
    private bool isSet = false; public bool IsSet { get { return isSet; } set { isSet = value; } }

    

    
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _camera = GameObject.Find("Main Camera");
        _cmSubMain = GameObject.Find("CM vcam1");
        _cmSub = GameObject.Find("CM vcam2");
        _cmSub.SetActive(false);
        _target = GameObject.Find("target").GetComponent<Image>();
        _normal = GameObject.Find("normal").GetComponent<Image>();
        _normal.enabled = true;
        _target.enabled = false;
        _moveSpeed = _walkSpeed;
    }
    private void Update()
    {

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
       
        _cmSub.transform.position = _cmSubMain.transform.position;
        _cmSub.transform.rotation = _cmSubMain.transform.rotation;
        

        if (!isSet)

        {

            _forward = Quaternion.AngleAxis(_camera.transform.eulerAngles.y, Vector3.up);
            _rb.velocity = _forward * new Vector3(x * _moveSpeed, 0, -z * _moveSpeed);
            float _rotateSpeed = 600 * Time.deltaTime;
            Vector3 fow = _rb.velocity;

            if (fow != Vector3.zero)
            {

                _rotation = Quaternion.LookRotation(fow, Vector3.up);
                
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, _rotateSpeed);


            _anim.SetFloat("walk", _rb.velocity.magnitude);

            if (_rb.velocity.magnitude > 0.1)
            {

                if (Input.GetButton("Run"))
                {
                    _anim.SetBool("run", true);
                    _moveSpeed = _runSpeed;
                }

                else
                {
                    _anim.SetBool("run", false);
                    _moveSpeed = _walkSpeed;
                }

            }


        }
        



        if (Input.GetButton("Upfream"))
        {
            isSet = true;
            _cmSub.SetActive(true);
            
            _cmSub.transform.position = _cmSubMain.transform.position;
            _cmSub.transform.rotation = _cmSubMain.transform.rotation;
            _rb.velocity = new Vector3(x * _moveSpeed, 0, -z * _moveSpeed);
            _forward = Quaternion.AngleAxis(_camera.transform.eulerAngles.y, Vector3.up) * Quaternion.Euler(0, 10, 0);
            transform.rotation = _forward * Quaternion.AngleAxis(_camera.transform.eulerAngles.x, Vector3.right);
            _normal.enabled = false;
            _target.enabled = true;
            _anim.SetBool("set", true);
        }
        else
        {
            
            _cmSub.SetActive(false);
            _anim.SetBool("set", false);
            _target.enabled = false;
            _normal.enabled = true;
            isSet = false;
            //_subcamera.enabled = false;
        }

        
    }

    
}
