using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Vector2 vec2;
    public LayerMask layerMask = 1 << 0;
    private float distance = 1000;
    [SerializeField] GameObject _sphere;
    [SerializeField] GameObject _rayInstate;
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
            Debug.Log(hit.collider.gameObject.name);
            _sphere.transform.position = hit.point;
        }
        if (hit.collider == null)
        {

            Debug.Log("hit.collider null!");
            _sphere.transform.position = Vector3.zero;
        }
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green, 5, false);

    }
}
