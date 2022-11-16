using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    Animator _anim;
    [Tooltip("カメラのY軸方向の角度を取得する変数")] Quaternion _forward;
    /// <summary>MainCamera</summary>
    GameObject _mainCamera;

    /// <summary>VirtualCamera 三人称視点</summary>
    [Tooltip("主要カメラ")] GameObject _cmMain;

    /// <summary> VirtualCamera 三人称視点　プレイヤー近くの背後の画面</summary>
    [Tooltip("ズーム時のカメラ")] GameObject _cmSub;

    //[Tooltip("ズーム時の照準UI")] Image _target;
    //[Tooltip("普段時の照準UI")] Image _normal;

    Quaternion upperFoward;

    
    
    [SerializeField, Header("移動速度"), Tooltip("移動速度")] float _runSpeed = 7f;
    float _rotateSpeed = 600;
    Quaternion _rotationTo = Quaternion.identity;
    Quaternion _mainCamaraforward = Quaternion.identity;
    bool isSet = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        _mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        //カメラのy軸のオイラー角を取得
        _mainCamaraforward = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up);
        _rb.velocity = _mainCamaraforward.normalized * new Vector3(x * _runSpeed, 0, -z * _runSpeed);

        if (_rb.velocity.magnitude >= 1)
        {
            _rotationTo = Quaternion.LookRotation(_rb.velocity, Vector3.up);
        }

        //滑らかに回転させる
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _rotationTo, _rotateSpeed * Time.deltaTime);


        _anim.SetFloat("run", _rb.velocity.magnitude);
    }
}
