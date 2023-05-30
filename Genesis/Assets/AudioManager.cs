using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource Source;
    private int index;
    
    void Start()
    {
        Source.clip = playlist[0];
        Source.Play();
    }

    void Update()
    {
        if (!Source.isPlaying)
        {
            Source.clip = playlist[(++index) % playlist.Length];
            Source.Play();
        }
    }
}
