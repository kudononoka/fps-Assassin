using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    Animator _anim;
    [Tooltip("カメラのY軸方向の角度を取得する変数")] Quaternion _forward;
    /// <summary>MainCamera</summary>
    Camera _mainCamera;
    
    [Header("普段使うカメラ"), Tooltip("主要カメラ"),SerializeField] GameObject _cmMain;

    /// <summary> VirtualCamera 三人称視点　プレイヤー近くの背後の画面</summary>
    [Tooltip("ズーム時のカメラ")] GameObject _cmSub;

    

    Quaternion upperFoward;

    

    [SerializeField, Header("移動速度"), Tooltip("移動速度")] float _runSpeed = 7f;
    float _rotateSpeed = 600;
    Quaternion _rotationTo = Quaternion.identity;
    
    bool isSet = false;

    public bool IsSet { get => isSet; }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        _mainCamera = Camera.main;

        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //カメラのy軸のオイラー角を取得
        _forward = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        transform.rotation = _forward;

        _rb.velocity = _forward * new Vector3(x * _runSpeed, 0, -z * _runSpeed);

        //方向ベクトルをワールド空間からローカル空間に変換、アニメーションのBlendTreeのパラメーターに使う
        Vector3 dir = transform.InverseTransformDirection(_rb.velocity);

        if (Input.GetButton("Upfream"))
        {
            
            _cmMain.SetActive(false);
            _anim.SetBool("set",true);
            isSet = true;
        }
        else
        {
            
            _cmMain.SetActive(true);
            _anim.SetBool("set",false);
            isSet = false;
        }
       
        _anim.SetFloat("run", _rb.velocity.magnitude);
        _anim.SetFloat("run.x", dir.x);
        _anim.SetFloat("run.z", dir.z);
    }
}
