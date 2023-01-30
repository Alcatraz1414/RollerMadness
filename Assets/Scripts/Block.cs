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

        if (isCollider== false && collision.gameObject.tag=="Player")   // top �arp�nca daha puan d��mesin diye yapt�k
        {
            print(collision.gameObject.name);
            GetComponent<MeshRenderer>().material.color = Color.black;


            FindObjectOfType<ScoreManager>().score--;
            /*
             * b�yle de yap�albilir score de�erine daha �ok ula��lacaksa

            ScoreManager scoreManager= FindObjectOfType<ScoreManager>();
            scoreManager.score++;

             */
            isCollider = true;
        }



        print(FindObjectOfType<ScoreManager>().score);
    }
    
}
