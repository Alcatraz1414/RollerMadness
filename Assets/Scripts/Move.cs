using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    

    private Vector3 movement;
    [SerializeField] private float speed = 600f;
    private Rigidbody rigibody; 
    private TimeManager timeManager;

    [SerializeField] private GameObject deadEffect;

    // [SerializeField] private Vector3 movement;  private olmas�na ra�men inspectorda g�rmemizi sa�lar
    // [HideInInspector]public float y;    public olmas�na ra�men inspectorda g�r�nmemesini sa�l�yor

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        timeManager=FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeManager.gameOver==false && timeManager.gameFinish==false)    
        {
            MoveThePlayer();
        }

        if(timeManager.gameOver || timeManager.gameFinish)   // bunlar true ise �al��t�r
        {
            rigibody.isKinematic = true;
        }

        

    }

    private void MoveThePlayer()
    {
        // ilerleme k�sm�
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        movement = new Vector3(x, 0f, z);
      //  transform.position += movement;
       rigibody.AddForce(movement);   //d�nme fizi�i veriyor
    }

    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }

   

}
