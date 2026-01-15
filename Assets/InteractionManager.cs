using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    public UIManager uiManager;
    public FloweyManager floweyManager;
    public PotGalleryManager potGallery;
    public ButterflyVideoManager butterflyVideo;
    public WateringAudioManager wateringAudio;

    void Awake()
    {
        Instance = this;
    }

    public void OnObjectTapped(TapInteractable.InteractableType type)
    {
        switch (type)
        {
            case TapInteractable.InteractableType.butterfly:
                floweyManager.SetState(FloweyManager.FloweyState.ButterflyClicked);
                butterflyVideo.ToggleVideo();
                break;

            case TapInteractable.InteractableType.kantica:
                floweyManager.SetState(FloweyManager.FloweyState.WateringClicked);
                wateringAudio.PlayWateringAudio();
                break;

            case TapInteractable.InteractableType.saksijaDobra:
                potGallery.Toggle();
                floweyManager.SetState(FloweyManager.FloweyState.PotClicked);
                break;
        }
    }
}
