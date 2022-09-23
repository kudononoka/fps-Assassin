using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControllRay : MonoBehaviour
{
   
    private Transform _player;
    public LayerMask layerMask = 1 << 0;
    private float _distance = 20;
    private GameObject _go;
    private SkinnedMeshRenderer mesh;
    bool enemyhit;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>().IsBreak == false)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, _distance, layerMask))
            {

                if (hit.collider.CompareTag("Enemy"))
                {
                    enemyhit = true;
                    _go = hit.collider.gameObject;
                    //Debug.Log("敵です");
                    mesh = _go.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>();
                    //Debug.Log(Vector3.Distance(hit.point, transform.position) + ":" + Vector3.Distance(_player.position, transform.position));
                    if (Vector3.Distance(hit.point, transform.position) < Vector3.Distance(_player.position, transform.position))
                    {
                        mesh.material.color = new Color32(255, 255, 255, 122);
                    }
                    else if(mesh != null)
                    {
                        mesh.material.color = new Color32(255, 255, 255, 255);
                    }
                    
                }
                else if(mesh != null)
                {
                    mesh.material.color = new Color32(255, 255, 255, 255);
                }
            }

            if (hit.collider == null && enemyhit && mesh != null)
            {
                mesh.material.color = new Color32(255, 255, 255, 255);
            }
            
        }
        else if(FindObjectOfType<GameManager>().IsBreak)
        {
            enemyhit = false;
        }
    }
}
    