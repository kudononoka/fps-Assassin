using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    private Vector2 vec2;
    public LayerMask layerMask = 1 << 0;
    private float distance = 1000;
    [SerializeField] GameObject _sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance,layerMask))
        {
            
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1f);
            _sphere.transform.position = hit.point;
            /*if (hit.collider != null)
            {
                _sphere.SetActive(true);
                _sphere.transform.position = hit.point;
            }
            else
            {
                _sphere.SetActive(false);
            }*/

        }
        if (hit.collider == null)
        {
            Debug.Log("hit.collider null!");
            _sphere.transform.position = Vector3.zero;
        }

    }
}
