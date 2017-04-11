using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{

    // Use this for initialization
    float damping = 6.0f;
    public float rotationX = 0F;

    public Quaternion rotation;
    public float sensitivityX = 20F;
    public Camera camera;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float rotationY = 0F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    public float sensitivityY = 25F;
     float distance = 60;
    float minDistance = 20.0f;
    float maxDistance = 60.0f;
    public Quaternion originalRotation = new Quaternion(0, 0, 0, 1);
    void Start()
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotationX = Mathf.Lerp(rotationX, rotationX + Input.GetAxis("Mouse X") * sensitivityX, 0.05f);
            rotationY = Mathf.Lerp(rotationY, rotationY + Input.GetAxis("Mouse Y") * sensitivityY, 0.05f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            distance -= Input.GetAxis("Mouse ScrollWheel") * 8;

        }
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        rotationX = Mathf.Lerp(rotationX, rotationX + Input.GetAxis("Horizontal") * sensitivityX, 0.05f);

        rotationX = ClampAngle(rotationX, minimumX, maximumX);

        rotationY = ClampAngle(rotationY, minimumY, maximumY);

        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);

        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

        transform.localRotation = xQuaternion * yQuaternion;
        camera.fieldOfView =  distance;
    }
    public static float ClampAngle(float angle, float min, float max)
    {

        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
    public void SetLookAt(Vector2 look)
    {
        rotationX = look.y;
        rotationY = -look.x;
    }
}