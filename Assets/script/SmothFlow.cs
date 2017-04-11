using UnityEngine;
using System.Collections;

public class SmothFlow : MonoBehaviour {


public float minDistance = 3.0f;
public float maxDistance = 12.0f;
public float minY = 20.0f;
public float maxY = 70.0f;
public float zoomSpeed = 1.0f;
public float distanceDamping = 3.0f;
private float distanceTemp;

// The target we are following
public GameObject target;
// The distance in the x-z plane to the target
public float distance = 13;
// the height we want the camera to be above the target
public float height = 5;
// How much we 
public float heightDamping = 2.0f;
public float rotationDamping = 3.0f;

private float lastFormPositionX  = 0;
private float lastFormPositionY  = 0;
private bool isDrag = false; 
private Vector2 currentPosition = Vector2.zero;
private float cf = 1f;
public float Y = 0;
public bool isoverview = true;
    // Place the script in the Camera-Control group in the component menu
    //@script AddComponentMenu("Camera-Control/Smooth Follow")
    void Start()
    {
       // height = distance;
        if (target != null)
        {
            target.transform.eulerAngles = new Vector3(0,200,0);
        }
    }
    
    void Update()
    {
            float wantedRotationAngle = 0.0f;
            float wantedRotationAnglex = 0.0f;
            float wantedHeight = 0.0f;
            float currentRotationAngle = 0.0f;
            float currentRotationAnglex = 0.0f;
            float currentHeight = 0.0f;
            Quaternion currentRotation;
            target = GameObject.Find("smoothLookatTarget");
            if (!target)
                return;

            if (Input.GetMouseButton(0))
            {
                Y -= Input.GetAxis("Mouse Y") * Time.deltaTime * 50;
                target.transform.eulerAngles -= new Vector3(0, -Input.GetAxis("Mouse X") * Time.deltaTime * 60, 0);
                Y = ClampAngle(Y, minY, maxY);
            }

            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                distance -= Input.GetAxis("Mouse ScrollWheel") * 8;
                
            }
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
            wantedRotationAngle = target.transform.eulerAngles.y;
            wantedRotationAnglex = Y; //Mathf.Clamp(wantedRotationAnglex, 20, 70);
            wantedHeight = target.transform.position.y + height;

            currentRotationAngle = transform.eulerAngles.y;
            currentRotationAnglex = Y;
            currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            currentRotationAnglex = Mathf.LerpAngle(currentRotationAnglex, wantedRotationAnglex, rotationDamping * Time.deltaTime);
            //print(currentRotationAnglex.ToString());
            currentRotationAnglex = Mathf.Clamp(currentRotationAnglex, minY, maxY);

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

            // Convert the angle into a rotation
            currentRotation = Quaternion.Euler(currentRotationAnglex, currentRotationAngle, 0);


            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            transform.position = target.transform.position;
            transform.position -= currentRotation * Vector3.forward * distance;
            transform.LookAt(target.transform);
    }
    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}    
