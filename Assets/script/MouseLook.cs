using UnityEngine;
using System.Collections;
//using DK.Apex.ColdGUI;//weng2011.1.4

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 8F;
	public float sensitivityY = 8F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	
	float rotationY = 0F;
	
	
    //public GUIGroup imageGroup = null;
    //public GUIGroup treeGroup = null;//weng...2011.1.4
	//public GUILabel movingLabel = null;//weng..2011.1.5

	
	//private float beginTime = 0;
	//private float endTime = 0;
	
	//private bool isDrag = false;
	//private bool isChange = false;
	//private bool isFirst = true;
	private bool isMove = false;
	private float lastFormPositionX = 0;
	private float lastFormPositionY = 0;
	private float cf = 1f;
	private Vector2 currentPosition = Vector2.zero;

    //涓虹紦鍔ㄥ姛鑳芥坊鍔犲彉閲幪
    public float rotationDamping = 5f;
    float wanteAngleX;
    float wangteAngleY;
    float currentX;
    Transform target;

	void Update ()
	{
        //Debug.Log(Input.touchCount);
        //if (!isDrag)
        //{
        //    lastFormPositionX = currentPosition.x;
        //    lastFormPositionY = currentPosition.y;
        //}
		//if(Input.mousePosition.x<Screen.width*0.8118f && Input.mousePosition.y<Screen.height*0.927f){
            
			if (axes == RotationAxes.MouseXAndY)
			{
				float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
				
				//rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY += Mathf.Clamp(0.05f * (lastFormPositionY - currentPosition.y), -cf, cf) * sensitivityY;
				rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				
				transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			}
			//else if (axes == RotationAxes.MouseX && isDrag)
            else if (axes == RotationAxes.MouseX && Input.GetMouseButton(0))
			{
				//transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0); //鍘熶唬鐮?
				//2011.1.14b
				//~ if(isFirst){
					//~ isFirst = false;
					//~ //print(11);
					//~ return;
				//~ }


                target.Rotate(0, Mathf.Clamp(0.05f * (currentPosition.x - lastFormPositionX), -cf, cf) * sensitivityX, 0);
                wanteAngleX = target.eulerAngles.y;



                //currentX = transform.eulerAngles.y;//杞?姩鍓嶇殑瑙掑害
                //currentX = Mathf.LerpAngle(currentX, wanteAngleX, rotationDamping * Time.deltaTime);
                //transform.rotation = Quaternion.Euler(0, currentX, 0);
                ////transform.Rotate(0, wanteAngleX, 0);//淇?敼鐨冺
                //lastFormPositionX = currentPosition.x;

				//2011.1.14e
				
				//HideGUI();//weng2011.1.4
				//endTime= Time.time; 2011.1.14z
			}
            //else if(isDrag && !isMove)
            else if(Input.GetMouseButton(0) && !isMove)
			{
				//~ if(isFirst){
					//~ isFirst = false;
					//~ return;
				//~ }
				//rotationY += Input.GetAxis("Mouse Y") * sensitivityY; 鍘熶唬鐮?
				//2011.1.14b
				//rotationY += Mathf.Clamp(0.05f*(lastFormPositionY-currentPosition.y),-cf,cf) * sensitivityY;//鏀圭殑.~涓虹紦鍔ㄦ敞閲婃帀
				
				
				//~ transform.Rotate(0, Mathf.Clamp(0.05f*(currentPosition.y-lastFormPositionY),-cf,cf) * sensitivityX, 0);//淇?敼鐨冺
				//~ lastFormPositionY = currentPosition.y;
				//2011.1.14e
                wangteAngleY = rotationY + Mathf.Clamp(0.05f * (lastFormPositionY - currentPosition.y), -cf, cf) * sensitivityY;
                
				
				//rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
				//transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);  //yuan
				
				
				
				//HideGUI();//weng2011.1.4
				//endTime = Time.time; 2011.1.14z
			}
            if (axes == RotationAxes.MouseX)
            {
                //float currentX = transform.eulerAngles.y;//杞?姩鍓嶇殑瑙掑害
                currentX = Mathf.LerpAngle(currentX, wanteAngleX, rotationDamping * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, currentX, 0);
                //transform.Rotate(0, wanteAngleX, 0);//淇?敼鐨冺
                lastFormPositionX = currentPosition.x;
            }
            else if(axes == RotationAxes.MouseY)
            {
                lastFormPositionY = currentPosition.y;
                rotationY = Mathf.LerpAngle(rotationY, wangteAngleY, rotationDamping * Time.deltaTime);
                rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
                
            }
			//~ if(!isDrag){
				//~ isFirst = true;
			//~ }
			
		//}
		//~ if(Input.GetKeyDown(KeyCode.Mouse0)){
			//~ beginTime = Time.time;
		//~ }
		//~ if(Input.GetKeyUp(KeyCode.Mouse0)){
			//~ if(!movingLabel.Visible){
				//~ ShowGUI();
			//~ }
			//~ beginTime = 0;
			//~ endTime = 0;
		//~ }
		//~ if(endTime-beginTime > 0.1f){
			//~ HideGUI();
		//~ }
        //if(isDrag || isMove || (Input.GetAxis("Fire1")==1 && Input.mousePosition.x<Screen.width*0.8118f && Input.mousePosition.y<Screen.height*0.927f)){// || (Input.GetAxis("Fire1")==1 && Input.mousePosition.x<Screen.width*0.8118f)){
        //    HideGUI();
        //}else{
        //    //if(!movingLabel.Visible && !isMove && Input.GetAxis("Fire1")!=1){// && Input.GetAxis("Fire1")!=1){
        //        ShowGUI();
        //    //}
        //}
		//Debug.Log(Input.GetAxis("Fire1"));
		
	}
    ////weng2011.1.4
    //private void ShowGUI(){
    //    imageGroup.Visible = true;
    //    imageGroup.Enabled = true;
    //    treeGroup.Visible = true;
    //    treeGroup.Enabled = true;
    //}
    //private void HideGUI(){
    //    imageGroup.Visible = false;
    //    imageGroup.Enabled = false;
    //    treeGroup.Visible = false;
    //    treeGroup.Enabled = false;
    //}
    ////weng2011.1.4
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
        target = new GameObject().transform;
        target.rotation = transform.rotation;
        currentX = target.eulerAngles.y;
        wanteAngleX = currentX;
	}
	
	void OnGUI(){
        //if(Event.current.type == EventType.MouseDrag){
        //    isDrag = true;
        //                //~ if(!isChange){
        //        //~ lastFormPositionX = Event.current.mousePosition.x;
        //        //~ lastFormPositionY = Event.current.mousePosition.y;
        //        //~ isChange = true;
        //    //~ }
        //}else{
        //    isDrag = false;
        //    //isFirst = true;
        //    //isChange = false;
        //}
		//print(isFirst);
		currentPosition = Event.current.mousePosition;
	}
	public void consumeDeltaX(bool isMoving){
		if(Input.mousePosition.y>Screen.height*0.927f) return;
		isMove = isMoving;
	}
	public void consumeDeltaY(bool isMoving){
		if(Input.mousePosition.y>Screen.height*0.927f) return;
		isMove = isMoving;
	}
}