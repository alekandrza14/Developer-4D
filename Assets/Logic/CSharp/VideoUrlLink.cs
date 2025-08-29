using UnityEngine;
using UnityEngine.Video;

public class VideoUrlLink : MonoBehaviour
{
    public VideoPlayer player;
    void Start()
    {
        player.url = "res/Movie.mp4";
        player.Play();
    }
}
