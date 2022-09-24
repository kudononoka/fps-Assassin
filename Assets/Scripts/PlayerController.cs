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
    private Camera _cam;
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

    private float _moveSpeed = 3f;
    private float _walkSpeed = 3f;
    private float _runSpeed = 7f;
    private bool isSet = false; public bool IsSet { get { return isSet; } set { isSet = value; } }

    private bool isAvoidance;

   [SerializeField] GameObject _particle;

    private ParticleSystem _particleSystem;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _camera = GameObject.Find("Main Camera");
        _cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        _cmSubMain = GameObject.Find("CM vcam1");
        _cmSub = GameObject.Find("CM vcam2");
        _cmSub.SetActive(false);
        _target = GameObject.Find("target").GetComponent<Image>();
        _normal = GameObject.Find("normal").GetComponent<Image>();
        _normal.enabled = true;
        _target.enabled = false;
        _moveSpeed = _walkSpeed;
        _particleSystem = _particle.GetComponent<ParticleSystem>();
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

            /*if (fow != Vector3.zero)
            {

                _rotation = Quaternion.LookRotation(fow, Vector3.up);
                
            }*/

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, _rotateSpeed);

            transform.rotation = _forward;  //向きを固定


            

            _anim.SetFloat("walk", _rb.velocity.magnitude);

            if(_rb.velocity.magnitude > 0.1)
            {
                if(Input.GetButton("Run"))
                {
                    _anim.SetBool("run",true);
                    _moveSpeed = _runSpeed;
                }
                else
                {
                    _anim.SetBool("run",false);
                    _moveSpeed = _walkSpeed;
                }
            }
            
         

        }
        



        if (Input.GetButton("Upfream"))
        {
            isSet = true;
            _cmSub.SetActive(true);
            _cam.fieldOfView = 5;
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
            //_cam.fieldOfView = 16;
            _cmSub.SetActive(false);
            _anim.SetBool("set", false);
            _target.enabled = false;
            _normal.enabled = true;
            isSet = false;
            //_subcamera.enabled = false;
        }

        
    }
    



}
