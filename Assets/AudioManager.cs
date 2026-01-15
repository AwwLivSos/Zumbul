using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    public void ToggleMute()
    {
        musicSource.mute = !musicSource.mute;
    }
}
