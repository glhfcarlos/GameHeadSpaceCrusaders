using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SplashVideoController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += EndReached; 
    }

    // Update is called once per frame
    void EndReached(VideoPlayer vp)
    {
        gameObject.SetActive(false); 
    }
}
