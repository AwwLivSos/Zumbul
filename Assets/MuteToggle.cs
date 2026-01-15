using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    private Image buttonImage;
    private bool isMuted = false;
    public AudioSource musicSource;

    void Start() { buttonImage = GetComponent<Image>(); }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        musicSource.mute = isMuted;
        buttonImage.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }
}