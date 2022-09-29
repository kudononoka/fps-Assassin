using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public LayerMask layerMask = 1 << 0;
    [Tooltip("Rayの長さ")] float distance = 1000;
    [SerializeField,Tooltip("Rayの当たった場所を取得　銃弾の方向を決めるもの")] GameObject _sphere;
    [SerializeField,Tooltip("Playerの所から生成")] GameObject _rayInstate;
    Vector3 _raypos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _raypos = _rayInstate.transform.position;
        Ray ray = new Ray(_raypos, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance,layerMask))
        {
            _sphere.transform.position = hit.point;
        }
        if (hit.collider == null)
        { 
            _sphere.transform.position = Vector3.zero;
        }
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.green, 5, false);

    }
}
