using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	// Use this for initialization
    AudioSource audio;
	void Start () {
        audio = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Play(string audiopath) 
    {
        if (audiopath != string.Empty)
        {
            AudioClip clip = GetAudio(audiopath);
            PlayAudioClip(clip);
        }
    }
    public void PlayAudioClip(AudioClip clip)
    {

        if (clip == null)

            return;

        AudioSource source = this.GetComponent<AudioSource>();

        /*if (source == null)

            source = (AudioSource)gameObject.AddComponent("AudioSource");*/

        source.clip = clip;

        source.minDistance = 1.0f;

        source.maxDistance = 50;

        source.rolloffMode = AudioRolloffMode.Linear;

        source.transform.position = transform.position;

        source.Play();

    }
    AudioClip GetAudio(string audio_path)
    {
        AudioClip clip = new AudioClip ();
        clip = (AudioClip)Resources.Load(audio_path, typeof(AudioClip));//调用Resources方法加载AudioClip资源
        if (clip == null)
        {
 
        }
        return clip;
    }


}
