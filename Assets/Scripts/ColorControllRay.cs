using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControllRay : MonoBehaviour
{
    [Tooltip("Playerの位置")] Transform _player;
    public LayerMask layerMask = 1 << 0;
    [Tooltip("Rayの長さ")] float _distance = 20;
    private GameObject _go;
    //private GameObject hitedenemyGo;
    private SkinnedMeshRenderer mesh;
    bool enemyhit = false;
    //List<GameObject> hitedenemy = new List<GameObject>();
    
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
            
            if(Physics.Raycast(ray, out hit,_distance,layerMask))
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    enemyhit = true;
                    
                    _go = hit.collider.gameObject;
                    
                    mesh = _go.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();
                    if (Vector3.Distance(_go.transform.position, transform.position) < Vector3.Distance(_player.position, transform.position))
                    {
                        
                        mesh.material.color = new Color32(255, 255, 255, 100);
                    }
                }
            }

            if (mesh != null && enemyhit && hit.collider == null)
            {
                mesh.material.color = new Color32(255, 255, 255, 255);
                enemyhit = false;
            }

            /*Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, _distance, layerMask);

            //Debug.Log(hits.Length);
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {

                    _go = hit.collider.gameObject;


                    mesh = _go.transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>();
                    //Debug.Log(Vector3.Distance(hit.point, transform.position) + ":" + Vector3.Distance(_player.position, transform.position));
                    if (Vector3.Distance(hit.transform.position, transform.position) < Vector3.Distance(_player.position, transform.position))
                    {
                        mesh.material.color = new Color32(255, 255, 255, 100);

                    }
                }
            }


            if (mesh != null)
            {
                mesh.material.color = new Color32(255, 255, 255, 255);
            }*/

        }
        else if (FindObjectOfType<GameManager>().IsBreak)
        {
            enemyhit = false;
        }
    }
}
    