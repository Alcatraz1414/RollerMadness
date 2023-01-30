using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isCollider=false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {

        if (isCollider== false && collision.gameObject.tag=="Player")   // top çarpýnca daha puan düþmesin diye yaptýk
        {
            print(collision.gameObject.name);
            GetComponent<MeshRenderer>().material.color = Color.black;


            FindObjectOfType<ScoreManager>().score--;
            /*
             * böyle de yapýalbilir score deðerine daha çok ulaþýlacaksa

            ScoreManager scoreManager= FindObjectOfType<ScoreManager>();
            scoreManager.score++;

             */
            isCollider = true;
        }



        print(FindObjectOfType<ScoreManager>().score);
    }
    
}
