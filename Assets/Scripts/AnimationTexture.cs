using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AnimationOrTween;

public class AnimationTexture : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	}
	public bool ActivateWait = false;
    UIAtlas atlas;
	public float fireRate = 0.2f;
	int i = 1;
	float nextFire;
	public string ActivatorTexture;
	public Transform p1;
	public Transform p2;
	void Awake()
	{
		this.GetComponent<UISprite>().enabled = false;
		atlas = this.GetComponent<UISprite> ().atlas;
		//MoveTo (p1,p2,10f);
	}
	void OnGUI()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			//SetOrientationL ();
			this.GetComponent<UIPlayTween> ().playDirection = Direction.Toggle;
			this.GetComponent<UIPlayTween> ().Play (true);
		
		}
		if (Input.GetKeyDown(KeyCode.S))
		{	
			//SetOrientationR ();
			this.GetComponent<UIPlayTween> ().playDirection = Direction.Toggle;
			this.GetComponent<UIPlayTween> ().Play (true);
		}
	}
	// Update is called once per frame
	void Update()
	{
		if (ActivateWait)
		{
			this.GetComponent<UISprite>().enabled = true;
			if (i < atlas.spriteList.Count+1)
			{
				if (Time.time > nextFire)
				{
					nextFire = Time.time + fireRate;
					int index = i.ToString ().Length; 
					string num = "0000";
					num = num.Remove (num.Length-index,index);
					num =num + i.ToString ();
					this.GetComponent<UISprite>().spriteName= ActivatorTexture+num.ToString();
					i++;
					Debug.LogWarning ("ActivatorTexture+num.ToString()"+ActivatorTexture+num.ToString());
				}
			}
			else
			{
				i = 1;
			}
		}
		else
		{
			this.GetComponent<UISprite>().enabled = false;
		}
	}
	public void SetOrientationL()
	{
		this.GetComponent<UIPlayTween> ().playDirection = Direction.Forward;
		this.GetComponent<UIPlayTween> ().Play (true);
		this.transform.localEulerAngles = Vector3.zero;
	}
	public void SetOrientationR()
	{

		Transform a = this.GetComponent<TweenTransform> ().from;
		Transform b = this.GetComponent<TweenTransform> ().to;
		this.transform.localEulerAngles = new Vector3 (0,180,0);	
		if(this.GetComponent<TweenTransform>())
		{
			GameObject.Destroy (this.GetComponent<TweenTransform> ());
		}
		MoveTo (b,a,10f);
		//this.GetComponent<UIPlayTween> ().Play (true);	
	}
	void MoveTo(Transform formObj,Transform toObj,float seconds,List<EventDelegate>  listevent = null )
	{
		this.gameObject.AddComponent<TweenTransform> ();
		this.gameObject.GetComponent<TweenTransform> ().from = formObj;
		this.gameObject.GetComponent<TweenTransform> ().to = toObj;
		this.gameObject.GetComponent<TweenTransform> ().duration = seconds;
	}
}