using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;
    public bool useOffsetValue;
    public float rotateSpeed;
    public Transform pivot;
    void Start()
    {
        if (!useOffsetValue)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

              
    }

    // Update is called once per frame
    void Update()
    {
        

        // get y position of mouse and rotate the pivot
        float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
        pivot.Rotate(vertical, 0, 0);


        //get x position of mouse to rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;
        transform.LookAt(target);
        
    }
}
