using UnityEngine;
using UnityEngine.Video;

public class ButterflyVideoManager : MonoBehaviour
{
    public GameObject videoPlane;    // Drag the Plane here
    public VideoPlayer videoPlayer;  // Drag the Plane (or VideoPlayer) here
    public AudioSource bgMusic;      // Drag your AudioSource here

    void Start()
    {
        videoPlane.SetActive(false); // Hide at start
        videoPlayer.loopPointReached += OnVideoFinished; // Listen for the end
    }

    public void ToggleVideo()
    {
        if (videoPlane.activeSelf)
        {
            StopVideo();
        }
        else
        {
            PlayVideo();
        }
    }

    void PlayVideo()
    {
        videoPlane.SetActive(true);
        videoPlayer.Play();
        if (bgMusic != null) bgMusic.mute = true;
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
        videoPlane.SetActive(false);
        if (bgMusic != null) bgMusic.mute = false;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        StopVideo();
    }
}