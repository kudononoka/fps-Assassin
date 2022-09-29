using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    Animator _anim;
    [Tooltip("カメラのY軸方向の角度を取得する変数")]Quaternion _forward;
  　/// <summary>MainCamera</summary>
    GameObject _mainCamera;

    /// <summary>VirtualCamera 三人称視点</summary>
    [Tooltip("主要カメラ")]GameObject _cmMain;

    /// <summary> VirtualCamera 三人称視点　プレイヤー近くの背後の画面</summary>
    [Tooltip("ズーム時のカメラ")]GameObject _cmSub;

    [Tooltip("ズーム時の照準UI")]Image _target;
    [Tooltip("普段時の照準UI")]Image _normal;

    Quaternion upperFoward;
   
    [Tooltip("移動速度")]private float _moveSpeed = 3f;
    [SerializeField,Header("歩行速度"),Tooltip("歩行速度")]float _walkSpeed = 3f;
    [SerializeField, Header("走行速度"), Tooltip("走行速度")]float _runSpeed = 7f;
    bool isSet = false;  

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _mainCamera = GameObject.Find("Main Camera");
        _cmMain = GameObject.Find("CM vcam1");
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
       
        _cmSub.transform.position = _cmMain.transform.position;
        _cmSub.transform.rotation = _cmMain.transform.rotation;
        
        if (!isSet)
        {
            _forward = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up);
            _rb.velocity = _forward.normalized * new Vector3(x * _moveSpeed, 0, -z * _moveSpeed);
            
            //Vector3 fow = _rb.velocity;
            //if (fow != Vector3.zero)
            //{
            //    _rotation = Quaternion.LookRotation(fow, Vector3.up); 
            //}
            //float _rotateSpeed = 600 * Time.deltaTime;
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotation, _rotateSpeed);


            transform.rotation = _forward; //プレイヤーの全体の向きをカメラと一緒にする
            upperFoward = Quaternion.Euler(0, 40, 0); //上半身のアニメーション修正のため現在のプレイヤーの角度に上半身だけ+40度


            _anim.SetFloat("walk", _rb.velocity.magnitude);
            
           

            if(_rb.velocity.magnitude > 0.1)
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

                if (x < 1 && x > -1)
                {
                    _anim.SetBool("runningVelocity.z", true);
                }
                else if (x != 0)
                {
                    _anim.SetBool("runningVelocity.z", false);
                    _anim.SetFloat("runningVelocity.x",x);
                }
               
            }
           
        }
        


        //ズーム
        if (Input.GetButton("Upfream"))
        {
            isSet = true;

            _cmSub.SetActive(true);
            _cmSub.transform.position = _cmMain.transform.position;
            _cmSub.transform.rotation = _cmMain.transform.rotation;

            _rb.velocity = new Vector3(x * _moveSpeed, 0, -z * _moveSpeed);
            _forward = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up) * Quaternion.Euler(0, 10, 0);
            transform.rotation = _forward * Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.x, Vector3.right);

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
        }

        
    }

    private void OnAnimatorIK(int layerIndex) //上半身のアニメーション修正のため
    {
        _anim.SetBoneLocalRotation(HumanBodyBones.Chest, upperFoward);
    }


}
