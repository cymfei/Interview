using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {

    public float MaxSpeedRotation = 2;
    // Use this for initialization
    void Start () {
		
	}

    private float rot = 0;
	// Update is called once per frame
	void Update () {
        rotateCamera();
    }

    private void rotateCamera()
    {
        rot += Input.GetAxis("Horizontal") * MaxSpeedRotation;
        Camera.main.transform.localRotation = Quaternion.AngleAxis(rot + 5, Vector3.up);
    }
}
