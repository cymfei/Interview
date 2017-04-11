using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	// Use this for initialization
    public string PathURL;
    //public GameObject CurrentObj; 
	void Start () {
        PathURL = "file://" + Application.streamingAssetsPath + "/IOS";

	}
	// Update is called once per frame
	void Update () {

	}
    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 100, 100), "加载美少女")) { StartCoroutine(GetAssetBundleObj("TemBackGroundPage", PathURL)); } 

    }
    /// <summary>
    /// 加载场景
    /// </summary>
    void LoadScene()
    {
 
    }
    /// <summary>
    /// 加载模块
    /// </summary>
    void LoadModule() 
    {
 
    }
    public static IEnumerator GetAssetBundleObj(string objName, string path = "")
    {
        string filePath = System.IO.Path.Combine(path, objName);

        WWW w = new WWW(filePath);         //利用www类加载 
        yield return w;
        AssetBundle curBundleObj = w.assetBundle;     //获得AssetBundle 

        AssetBundleRequest obj = curBundleObj.LoadAssetAsync(objName, typeof(GameObject));    //异步加载GameObject类型 
        yield return obj;
        GameObject CurrentObj = new GameObject();
        CurrentObj = Instantiate(obj.asset) as GameObject;

        yield return null;
        curBundleObj.Unload(false);     //卸载所有包含在bundle中的对象,已经加载的才会卸载 
        w.Dispose();
    } 

    
}
