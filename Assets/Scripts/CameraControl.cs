using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;
    public bool useOffsetValue;
    public float rotateSpeed;
    public Transform pivot;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;
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
    void LateUpdate()
    {
        

        // get y position of mouse and rotate the pivot
        float vertical = Input.GetAxis ("Mouse Y") * rotateSpeed;
       // pivot.Rotate(vertical, 0, 0);

    if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
    else
        {
            pivot.Rotate(-vertical, 0, 0);
        }


        //limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);

        }

        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f+ minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        //get x position of mouse to rotate target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.Rotate(0, horizontal, 0);

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;
        transform.LookAt(target);
        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }
    }
}
