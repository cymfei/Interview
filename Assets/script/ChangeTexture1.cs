using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture1 : MonoBehaviour {

    private Texture[] frames;
    public int fileNum = 5394;
    //public int framesPerSecond = 30; //声明fps,每秒播放几帧，影响动画的速度。
    public int maxSpeed = 30;

    // Use this for initialization
    void Start () {
        //frames = Resources.LoadAll<Texture>("texture");
    }

    private float index2 = -1;
    private float index = 0;
    // Update is called once per frame
    void Update() {
        int speed = (int)(Input.GetAxis("Vertical")* maxSpeed);
        index = index + speed * Time.deltaTime;
        if (index < 0)
            index = 39;
        else if (index > (fileNum - 1))
            index = 0;
        //index = (int)((Time.time * framesPerSecond) % fileNum); //数组的索引，根据时间改变，当前时间乘以fps与总帧数取余，就是播放的当前帧，随着update更新
        if ((int)(index) != (int)(index2))
        { 
            string str = "";
            int num = Mathf.RoundToInt(index);
            for (int i = 3; i >= 0; i--)
            {
                if (num < Mathf.Pow(10, i))
                    str += "0";
                else
                    str += (int)(num / Mathf.Pow(10, i));
                num = (int)(num % Mathf.Pow(10, i));
            }
            Debug.Log(str);
            Resources.UnloadAsset(GetComponent<Renderer>().material.mainTexture);
            GetComponent<Renderer>().material.mainTexture = Resources.Load<Texture>("texture/my_" + str);
            index2 = index;
        }
    }
}
