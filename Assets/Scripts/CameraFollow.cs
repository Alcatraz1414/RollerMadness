using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;

    [SerializeField] private float cameraFollowSpeed = 5f;  //yumuþak kamera

    private Vector3 offsetVector; 


    // Start is called before the first frame update
    void Start()
    {
        offsetVector = CalculateOffset(target);
    }

    // Update is called once per frame
    void Update()
    {//normalde void FixedUptade() kullanýyoruz ama bende titreþerek gidiyor??      //yumuþak kameara

        //basit kamera: transform.position = target.position + offsetVector;

        if (target != null)
        {
            MoveTheCamera();
        }
        

    }

    private void MoveTheCamera() {

        // yumuþak kamera
        Vector3 targetToMove = target.position + offsetVector;
        transform.position = Vector3.Lerp(transform.position, targetToMove, cameraFollowSpeed * Time.deltaTime);

        transform.LookAt(target.transform.position);
    }

    private Vector3 CalculateOffset(Transform newTarget)
    {
        return transform.position-newTarget.position;      
    }

}
