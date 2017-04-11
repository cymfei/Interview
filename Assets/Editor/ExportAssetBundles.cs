using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

public class ExportResourcesWizard : ScriptableWizard
{
    static string _homeUrl = string.Empty;
    static string _hhmjVersionUrl = "";
    static string _sAndroidExportDir = _homeUrl + "Assets/streamingassets/Android";
    static string _siPhoneExportDir = _homeUrl + "Assets/streamingassets/IOS";
    static string _sStandaloneWindowsExportDir = _homeUrl + "Assets/streamingassets/Windows";
    static string _sWebGLExportDir = _homeUrl + "Assets/streamingassets/WebGL";
    //    const string _sMetroExtension = "";	//Metro资源后缀
    //    const string _sWP8PlayerExtension = "";	//WindowsPhone资源后缀
    const string _sAndroidExtension = "";															    //Android资源后缀
    const string _siPhoneExtension = "";																//IOS资源后缀
    const string _sStandaloneWindowsExtension = "";                                                     //standaloneWindows资源后缀
    const string _sWebGLExtension = "";                                                                 //WebGL资源后缀

    #region ExportResources

    static void CheckDir(string sDirPath)
    {
        if (!System.IO.Directory.Exists(sDirPath))
        {
            System.IO.Directory.CreateDirectory(sDirPath);
        }
    }


    public static void SetResUrl(string url)
    {
        _homeUrl = url;
        _sAndroidExportDir = _homeUrl + "Assets/streamingassets/Android";
        _siPhoneExportDir = _homeUrl + "Assets/streamingassets/IOS";
        _sStandaloneWindowsExportDir = _homeUrl + "Assets/streamingassets/Windows";
        _sWebGLExportDir = _homeUrl + "Assets/streamingassets/WebbGL";
    }





    static string GetWhichVersion(string url)
    {
//        SetResUrl(url);
//        if (_homeUrl == _hhmjVersionUrl)
//        {
//            return "\"黄骅麻将\"";
//        }
//        else if (_homeUrl == _symjVersionUrl)
//        {
//            return "\"沈阳麻将\"";
//        }
//        else if (_homeUrl == _stdVersionUrl)
//        {
//            return "\"国标麻将\"";
//        }
//        else if (_homeUrl == _hdVersionUrl)
//        {
//            return "\"邯郸麻将\"";
//        }
//        else
//        {
//            return "\"当前工程\"";
//        }
		return "";
    }



    [MenuItem("Assets/导出资源/所有平台")]
    public static void ExportResource()
    {
#if UNITY_ANDROID
        EditorUtility.DisplayDialog("导出资源", "选择"+GetWhichVersion(_hhmjVersionUrl)+"Windows资源路径", "确定");
        ExportSingleResource(BuildTarget.StandaloneWindows);
        EditorUtility.DisplayDialog("导出资源", "选择"+GetWhichVersion(_hhmjVersionUrl)+"IOS资源路径", "确定");
        ExportSingleResource(BuildTarget.iOS);
        EditorUtility.DisplayDialog("导出资源", "选择"+GetWhichVersion(_hhmjVersionUrl)+"Android资源路径", "确定");
        ExportSingleResource(BuildTarget.Android);
		EditorUtility.DisplayDialog("导出资源", "选择"+GetWhichVersion(_hhmjVersionUrl)+"WebGL资源路径", "确定");
		ExportSingleResource(BuildTarget.WebGL);
        EditorUtility.DisplayDialog("导出资源", "所有资源导出完毕", "确定");
#elif UNITY_IPHONE
        EditorUtility.DisplayDialog("导出资源", "选择"+GetWhichVersion(_hhmjVersionUrl)+"Windows资源路径", "确定");
        ExportSingleResource(BuildTarget.StandaloneWindows);
        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "Android资源路径", "确定");
		ExportSingleResource(BuildTarget.Android);
        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "IOS资源路径", "确定");
		ExportSingleResource(BuildTarget.iOS);
		EditorUtility.DisplayDialog("导出资源", "选择"+GetWhichVersion(_hhmjVersionUrl)+"WebGL资源路径", "确定");
		ExportSingleResource(BuildTarget.WebGL);
		EditorUtility.DisplayDialog("导出资源","所有资源导出完毕","确定");
#elif UNITY_STANDALONE
        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "IOS资源路径", "确定");
        ExportSingleResource(BuildTarget.iOS);
        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "Android资源路径", "确定");
        ExportSingleResource(BuildTarget.Android);
		EditorUtility.DisplayDialog("导出资源", "选择"+GetWhichVersion(_hhmjVersionUrl)+"WebGL资源路径", "确定");
		ExportSingleResource(BuildTarget.WebGL);
        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "Windows资源路径", "确定");
        ExportSingleResource(BuildTarget.StandaloneWindows);
        EditorUtility.DisplayDialog("导出资源", "所有资源导出完毕", "确定");

#elif UNITY_WEBGL 
		EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "IOS资源路径", "确定");
		ExportSingleResource(BuildTarget.iOS);
		EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "Android资源路径", "确定");
		ExportSingleResource(BuildTarget.Android);
		EditorUtility.DisplayDialog("导出资源", "选择"+GetWhichVersion(_hhmjVersionUrl)+"WebGL资源路径", "确定");
		ExportSingleResource(BuildTarget.WebGL);
		EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "Windows资源路径", "确定");
		ExportSingleResource(BuildTarget.StandaloneWindows);
		EditorUtility.DisplayDialog("导出资源", "所有资源导出完毕", "确定");
#else
		//TODO
#endif
    }

    [MenuItem("Assets/导出资源/Android平台")]
    static void ExportAndroid()
    {

        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "Android资源路径", "确定");
        ExportSingleResource(BuildTarget.Android);
        EditorUtility.DisplayDialog("导出资源", "所有资源导出完毕", "确定");
    }

    [MenuItem("Assets/导出资源/IOS平台")]
    static void ExportiPhone()
    {
        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "IOS资源路径", "确定");
        ExportSingleResource(BuildTarget.iOS);
        EditorUtility.DisplayDialog("导出资源", "所有资源导出完毕", "确定");
    }

    [MenuItem("Assets/导出资源/Windows平台")]
    static void ExportWindows()
    {
        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "Windows资源路径", "确定");
        ExportSingleResource(BuildTarget.StandaloneWindows);
        EditorUtility.DisplayDialog("导出资源", "所有资源导出完毕", "确定");
    }
    [MenuItem("Assets/导出资源/WebGL平台")]
    static void ExportWebGL()
    {
        EditorUtility.DisplayDialog("导出资源", "选择" + GetWhichVersion(_hhmjVersionUrl) + "WebGL资源路径", "确定");
        ExportSingleResource(BuildTarget.WebGL);
        EditorUtility.DisplayDialog("导出资源", "所有资源导出完毕", "确定");
    }
    static void ExportSingleResource(BuildTarget target)
    {

        Debug.Log("homeurl:" + _homeUrl);
        string sExportDir = "";
        string sExtension = "";

        switch (target)
        {

            case BuildTarget.Android:
                sExportDir = _sAndroidExportDir;
                sExtension = _sAndroidExtension;
                break;
            case BuildTarget.iOS:
                sExportDir = _siPhoneExportDir;
                sExtension = _siPhoneExtension;
                break;
            case BuildTarget.StandaloneWindows:
                sExportDir = _sStandaloneWindowsExportDir;
                sExtension = _sStandaloneWindowsExtension;
                break;

		    case BuildTarget.WebGL:
				sExportDir = _sWebGLExportDir;
				sExtension = _sWebGLExtension;
				break;
            default:
                break;
        }

        if (string.IsNullOrEmpty(sExportDir) && string.IsNullOrEmpty(sExtension))
        {
            UnityEngine.Debug.LogWarning("Platform Error!");
            return;
        }
        Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        if (selection.Length == 0)
        {
            UnityEngine.Debug.LogWarning("Nothing selected!");
            return;
        }

        CheckDir(sExportDir);

        string sExportName = selection[0].name;
        // Bring up save panel
        string sResPath = EditorUtility.SaveFilePanel("Save Resources", sExportDir, sExportName, sExtension);


        UnityEngine.Debug.Log(sResPath);
        int nNameIndex = sResPath.LastIndexOf('/');
        UnityEngine.Debug.Log(nNameIndex);
        string sResDir;
        if (nNameIndex == -1)
        {
            sResDir = "/";
        }
        else
        {
            sResDir = sResPath.Substring(0, nNameIndex + 1);
        }
        sExportName = sResPath.Substring(nNameIndex + 1).Split('.')[0];
        if (sResPath.Length != 0)
        {
            // Build the resource file from the active selection.


            //				BuildTarget buildtarget = Entry.getbuildtarget;
            bool bAssetBundleSuccessful = BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, sResPath, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, target);

            Selection.objects = selection;
            if (bAssetBundleSuccessful)
            {
                checkDotAllFileStr(sResDir + sExportName);

                string sPackagePath = sResDir + sExportName + ".unitypackage";
                string sListPath = sResDir + sExportName + ".txt";
                // Export a package file
                string[] a_sAssetPaths = new string[selection.Length];
                int nIndex = 0;
                foreach (Object exportedObject in selection)
                {
                    a_sAssetPaths[nIndex] = AssetDatabase.GetAssetPath(exportedObject.GetInstanceID());
                    nIndex++;
                }
                AssetDatabase.ExportPackage(a_sAssetPaths, sPackagePath, ExportPackageOptions.IncludeDependencies | ExportPackageOptions.Recurse);
                string[] a_sAssetDependenciesPaths = AssetDatabase.GetDependencies(a_sAssetPaths);
                // Export a list of the exported objects BTW
                System.IO.StreamWriter exportListStream = new System.IO.StreamWriter(sListPath);
                foreach (string sAssetPath in a_sAssetDependenciesPaths)
                {
                    exportListStream.WriteLine(sAssetPath.Substring(7));
                    UnityEngine.Debug.Log(sAssetPath.Substring(7));
                }
                exportListStream.WriteLine("--------------------");
                foreach (Object obj in selection)
                {
                    exportListStream.WriteLine(obj.name);
                }
                exportListStream.WriteLine("--------------------");
                exportListStream.WriteLine("target:" + target.ToString() + "~~Time:" + DateTime.Now);
                exportListStream.Close();
            }
        }
        // }

    }
    #endregion

    /// <summary>
    /// 去除可能出现的 .All Files 后缀名
    /// </summary>
    /// <param name="path"></param>
    static void checkDotAllFileStr(string path)
    {
        Debug.Log("removeDotAllFileStr() " + path);

        if (File.Exists(path + ".All files"))
        {
            string newName = path.Replace(".All files", "");
            File.Move(path + ".All files", newName);
            Debug.Log("已去除【.All files】");
        }
        else if (File.Exists(path + ".All files.All files"))
        {
            string newName = path.Replace(".All files", "");
            File.Move(path + ".All files.All files", newName);
            Debug.Log("已去除【.All files.All files】");
        }
        else
        {
            Debug.Log("未取到【.All files】后缀");
        }
    }



}