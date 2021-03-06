using System;
using UnityEngine;
using System.Collections;

public class MouseOrbit : MonoBehaviour 
{
	[SerializeField]
    public Transform target;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = 10f;
    public float yMaxLimit = 90f;

    public float initDis = 4f;
    public float minDis = 2.6f;
    public float maxDis = 6.0f;

    public float wheelSpeed = 5f;

    public bool isDrag = false;
    public bool isScale = false;
    public float x = 0.0f;
    public float y = 0.0f;

    public float distance;

    public Vector3 position;
    public Quaternion rotation;
	public float moveSpeed;
    public float cameraMoveSpeed = 500f;
    public float ZoomSpeed = 500f;
    public float maxZoomDistance = 2000f;
	void Start () 
	{
		x = 130f;
		y = 30f;
		transform.rotation = Quaternion.Euler(y, x, 0f);
		transform.position = Quaternion.Euler(y, x, 0f) * new Vector3(0.0f, 0.0f, -initDis) + target.position;
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	void Update () 
	{
		if (target) 
		{
			distance = Vector3.Distance(target.position,transform.position);
	        ZoomSpeed = distance * ZoomSpeed / maxZoomDistance + 10;
	        moveSpeed = distance * cameraMoveSpeed / maxZoomDistance + 10;
		    if(Input.GetMouseButton(0))
			{
			    x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			    y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			    y = ClampAngle(y, yMinLimit, yMaxLimit);
		    }
		    if(Input.GetKey("mouse 1") && isDrag)
			{
				distance -= Input.GetAxis("Mouse X") * ZoomSpeed * 0.02f;
		        distance -= Input.GetAxis("Mouse Y") * ZoomSpeed * 0.02f;
		    }
		    if(Input.GetKey("mouse 2") && isScale)
			{
				var leftHandSideMove = transform.TransformDirection(Vector3.left);
		        target.position += (leftHandSideMove* moveSpeed * Input.GetAxisRaw("Mouse X") * 0.02f);
		    } 
		    distance -= Input.GetAxis("Mouse ScrollWheel") * wheelSpeed;
		    distance = Mathf.Clamp(distance,minDis,maxDis);
		  
		    rotation = Quaternion.Euler(y, x, 0f);
		    position = Quaternion.Euler(y, x, 0f) * new Vector3(0.0f, 0.0f, -distance) + target.position;
		   
		    transform.rotation = rotation;
		    transform.position = position;
		}
	}
	
	float ClampAngle (float angle, float min,float  max) 
	{
		if (angle < -360f)
			angle += 360f;
		if (angle > 360f)
			angle -= 360f;
		return Mathf.Clamp (angle, min, max);
	}
}
