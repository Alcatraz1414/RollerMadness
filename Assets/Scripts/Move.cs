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

    // [SerializeField] private Vector3 movement;  private olmasýna raðmen inspectorda görmemizi saðlar
    // [HideInInspector]public float y;    public olmasýna raðmen inspectorda görünmemesini saðlýyor

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

        if(timeManager.gameOver || timeManager.gameFinish)   // bunlar true ise çalýþtýr
        {
            rigibody.isKinematic = true;
        }

        

    }

    private void MoveThePlayer()
    {
        // ilerleme kýsmý
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        movement = new Vector3(x, 0f, z);
      //  transform.position += movement;
       rigibody.AddForce(movement);   //dönme fiziði veriyor
    }

    private void OnDisable()
    {
        Instantiate(deadEffect, transform.position, transform.rotation);
    }

   

}
