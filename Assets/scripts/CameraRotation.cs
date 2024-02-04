using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public float RotationSpeed;
    public float minAngle;
    public float maxAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime*RotationSpeed*Input.GetAxis("Mouse X"), 0);
        var newAnglex = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (newAnglex > 180)
            newAnglex -= 360;
        newAnglex = Mathf.Clamp(newAnglex, minAngle, maxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(newAnglex, 0, 0);
    }
}
            