using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BulletRaycast : MonoBehaviour
{
    [SerializeField] LayerMask layerMask = 1 << 0;
    [Tooltip("Rayの長さ")] float distance = 1000;
    [SerializeField, Tooltip("Rayの当たった場所を取得　銃弾の方向を決めるもの")] GameObject _sphere;
    [SerializeField, Tooltip("Playerの所から生成")] GameObject _rayInstate;
    Vector3 _raypos;
    [SerializeField] PlayerMove _player;

    [Header("照準UI"), Tooltip("照準UI"), SerializeField] Image _target;
    [Header("照準UI"), Tooltip("照準UI"), SerializeField] Image _target2;

    GameObject _currentTargetEnemy;

    [SerializeField] Reload reload;

    [SerializeField] UnityEvent OnShoot;

    [SerializeField, Header("Enemyに与えるダメージ数")] int _enemyDamage;

    [SerializeField] BulletHitEffect _hitEffect;

    Vector3 hitPoint;

    float _timer;

    [SerializeField] float _bulletInterval = 0.1f;
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
            _currentTargetEnemy = isEnemy ? hit.collider.gameObject : null;
            hitPoint = isEnemy ? hit.point : Vector3.zero;
            if (Input.GetButton("Shoot") && reload.BulletNum != 0)
            {
                _timer += Time.deltaTime;
                if (_timer > _bulletInterval)
                {
                    OnShoot.Invoke();
                    if (_currentTargetEnemy)
                    {
                        _currentTargetEnemy.GetComponent<EnemyBase>().Hit(_enemyDamage);
                        _hitEffect.HitEffect(hit.point);
                    }
                    reload.OnShoot();
                    _timer = 0;
                }
            }
            else
            {
                _timer = 0;
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