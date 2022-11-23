using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletRaycast : MonoBehaviour
{
    [SerializeField] LayerMask layerMask = 1 << 0;
    [Tooltip("Rayの長さ")] float distance = 1000;
    [SerializeField,Tooltip("Rayの当たった場所を取得　銃弾の方向を決めるもの")] GameObject _sphere;
    [SerializeField,Tooltip("Playerの所から生成")] GameObject _rayInstate;
    Vector3 _raypos;
    [SerializeField] PlayerMove _player;

    [Header("照準UI"), Tooltip("照準UI"), SerializeField] Image _target;
    [Header("照準UI"), Tooltip("照準UI"), SerializeField] Image _target2;

    GameObject _currentTargetEnemy;

    [SerializeField] Reload reload;
    // Start is called before the first frame update
    void Start()
    {
        _target.enabled = false;
        _target2.enabled = false;
        _target.color = Color.white;
        _target2.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.IsSet)
        {
            _target.enabled = true;
            _target2.enabled = true;
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            
            bool isEnemy = Physics.Raycast(ray, out hit, distance, layerMask);
            _target.color = isEnemy ? Color.red : Color.white;
            _target2.color = isEnemy ? Color.red : Color.white;
            _currentTargetEnemy = isEnemy ? hit.collider.gameObject: null;

            if (Input.GetButtonDown("Shoot") && reload.BulletNum != 0)
            {
                if(_currentTargetEnemy)
                {
                    
                }
                reload.OnShoot();
            }

        }
        else
        {
            _sphere.transform.position = Vector3.zero;
            _target.enabled = false;
            _target2.enabled = false;
        }
        
        if (Input.GetButtonDown("Reload"))
        {
            reload.OnReload();
        }
    }
}
