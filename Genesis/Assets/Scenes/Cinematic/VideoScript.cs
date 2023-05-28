using Mirror;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
 
public class videoscript : MonoBehaviour
{
 
     public VideoPlayer video;
     public GameObject portal;

     public void Start()
    {
        video = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    private void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        portal.transform.position = new Vector2(0, 0);
    }
}
 