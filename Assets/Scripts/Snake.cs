using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Snake : MonoBehaviour
{
    
    private Transform player;
    private Rigidbody rb;
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
      
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        _anim.SetTrigger("Attack");
        _anim.SetFloat("AttackPlay", 0.1f);
        transform.Rotate(Vector3.back * 1);
        Vector3 pos = new Vector3 (player.position.x, player.position.y + 3, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, pos, 5 * Time.deltaTime);
        

    }
}
