using UnityEngine;
using System.Collections;

public class WateringAudioManager : MonoBehaviour
{
    public GameObject audioContainer; // Drag the AudioSource's GameObject here
    public AudioSource voiceOverSource; 
    public AudioSource bgMusic;         
    
    [Range(0, 1)] public float reducedVolume = 0.4f; // How quiet the music gets
    private float originalVolume;
    private bool isPlaying = false;

    void Start()
    {
        // Force the container OFF immediately so it can't play on awake
        if (audioContainer != null) audioContainer.SetActive(false);
        if (bgMusic != null) originalVolume = bgMusic.volume;
    }

    public void PlayWateringAudio()
    {
        if (isPlaying) return;
        StartCoroutine(PlayAndRestoreMusic());
    }

    IEnumerator PlayAndRestoreMusic()
    {
        isPlaying = true;

        // 1. Mute Background
        if (bgMusic != null) bgMusic.volume = reducedVolume;

        // 2. Enable the object and Play
        audioContainer.SetActive(true);
        voiceOverSource.Play();

        // 3. Wait for the clip to finish
        yield return new WaitForSeconds(voiceOverSource.clip.length);

        // 4. Clean up
        voiceOverSource.Stop();
        audioContainer.SetActive(false);
        
        if (bgMusic != null) bgMusic.volume = originalVolume;

        isPlaying = false;
    }
}