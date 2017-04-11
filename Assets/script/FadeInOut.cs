using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.02f;

    public int drawDepth = -1000;
    public float alpha = 1.0f;

    public int fadeDir = -1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {
        if (gameObject.active)
        {
            if (alpha < 0.9f)
            {
                fadeSpeed = 0.1f;
            }

            if (alpha < 0.8f)
            {
                fadeSpeed = 0.3f;
            }
            if (alpha < 0.7f)
            {
                fadeSpeed = 0.2f;
            }
            alpha += fadeDir * fadeSpeed * Time.deltaTime;

            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(1, 1, 1, alpha);

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        }

    }
    void fadeIn()
    {
        fadeDir = -1;
    }

    //--------------------------------------------------------------------

    void fadeOut()
    {
        fadeDir = 1;
    }
    public void SetAlpha(int a)
    {
        alpha = a;
    }
}
