using System;
using System.Collections;
using UnityEngine;

public class Move_video : MonoBehaviour {

    public UISlider _videoSeekSlider;
    private float _setVideoSeekSliderValue;
    private bool _wasPlayingOnScrub;
    public Material _viewMaterial;
    public UISlider _audioVolumeSlider;
    private float _setAudioVolumeSliderValue;
    
    public UIToggle _AutoStartToggle;
    public UIToggle _MuteToggle;
    public UILabel currrnMs;
    public UILabel durationMs; 
    void Start()
    {
        this.transform.FindChild("view").GetComponent<MeshRenderer>().material = _viewMaterial;

    }
    void Update()
    {

    }
    public void OnAutoStartChange()
    {
        /*if (_mediaPlayer &&
            _AutoStartToggle && _AutoStartToggle.enabled &&
            _mediaPlayer.m_AutoStart != _AutoStartToggle.value)
        {
            _mediaPlayer.m_AutoStart = _AutoStartToggle.value;
        }*/
    }

    public void OnMuteChange()
    {
        /*if (_mediaPlayer)
        {
            _mediaPlayer.Control.MuteAudio(_MuteToggle.value);
        }*/
    }

    public void OnPlayButton()
    {
        /*if (_mediaPlayer)
        {
            _mediaPlayer.Control.Play();
        }*/
    }
    public void OnPauseButton()
    {
        /*if (_mediaPlayer)
        {
            if (_mediaPlayer.Control.IsPlaying())
            {

                _mediaPlayer.Control.Pause();
            }
            else
            {
                _mediaPlayer.Control.Play();
            }

            //				SetButtonEnabled( "PauseButton", false );
            //				SetButtonEnabled( "PlayButton", true );
        }*/
    }

    public void OnVideoSeekSlider()
    {
        /*if (_mediaPlayer && _videoSeekSlider && _videoSeekSlider.value != _setVideoSeekSliderValue)
        {
            _mediaPlayer.Control.Seek(_videoSeekSlider.value * _mediaPlayer.Info.GetDurationMs());
        }*/
    }
    public void OnVideoSliderDown()
    {
        /*if (_mediaPlayer)
        {
            _wasPlayingOnScrub = _mediaPlayer.Control.IsPlaying();
            if (_wasPlayingOnScrub)
            {
                _mediaPlayer.Control.Pause();
                //					SetButtonEnabled( "PauseButton", false );
                //					SetButtonEnabled( "PlayButton", true );
            }
            OnVideoSeekSlider();
        }*/
    }
    public void OnVideoSliderUp()
    {
        /*if (_mediaPlayer && _wasPlayingOnScrub)
        {
            _mediaPlayer.Control.Play();
            _wasPlayingOnScrub = false;

            //				SetButtonEnabled( "PlayButton", false );
            //				SetButtonEnabled( "PauseButton", true );
        }*/
    }
    void LoadMovieRes()
    {
 
    }
    public void OnAudioVolumeSlider()
    {
        /*if (_mediaPlayer && _audioVolumeSlider && _audioVolumeSlider.value != _setAudioVolumeSliderValue)
        {
            _mediaPlayer.Control.SetVolume(_audioVolumeSlider.value);
        }*/
    }
    //void OnGUI()
    //{
    //    if(GUILayout.Button("播放/继续"))
    //    {
    //        //播放/继续播放视频
    //        if(!movTexture.isPlaying)
    //        {
    //            movTexture.Play();
    //            audio.enabled = movTexture.isPlaying;
    //        }

    //    }

    //    if(GUILayout.Button("暂停播放"))
    //    {
    //        //暂停播放
    //        movTexture.Pause();
    //    }

    //    if(GUILayout.Button("停止播放"))
    //    {
    //        //停止播放
    //        movTexture.Stop();
    //        audio.enabled = movTexture.isPlaying;
    //    }
    //}
}
