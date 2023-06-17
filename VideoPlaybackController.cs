using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlaybackController : MonoBehaviour
{
    //public GameObject gameplayObjects;
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    private bool videoStarted = false;

    public void Initialize()
    {
        videoPlayer.loopPointReached += OnVideoPlaybackCompleted;
        rawImage.enabled = false;
    }

    public void StartVideoPlayback()
    {
        videoStarted = true;
        rawImage.enabled = true;
        //gameplayObjects.SetActive(false);
        videoPlayer.Play();
    }

    private void OnVideoPlaybackCompleted(VideoPlayer vp)
    {
        videoStarted = false;
        rawImage.enabled = false;
        //gameplayObjects.SetActive(true);
        videoPlayer.Stop();
    }

    private void Update()
    {
        if (videoStarted && !videoPlayer.isPlaying)
        {
            OnVideoPlaybackCompleted(videoPlayer);
        }
    }
}
