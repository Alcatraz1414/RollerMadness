
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform target;  // burada unity içinde sürüklemiyouz onun yerine aþaðýdaki start metodu içinde oto yapýyor.
    [SerializeField] private float speed=3f;
    [SerializeField] private float stopDistance = 0.5f;

    [SerializeField] private bool gameOver=false;

    [SerializeField] private GameObject deadEffect;

    
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)  // Player tagli obje null deðilse altýndakine bak
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();  // target Playet tagli objenin transform deðeri
        }
        
        
    }

    
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            float distance = Vector3.Distance(transform.position, target.position);
            // print(distance);
            if (stopDistance < distance)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }
        

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<TimeManager>().gameOver=true;
        }
    }

    private void OnDisable()
    {
        Instantiate(deadEffect,transform.position,transform.rotation);
    }

}
