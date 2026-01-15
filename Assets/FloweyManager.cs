using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FloweyManager : MonoBehaviour
{
    public enum FloweyState
    {
        Start,
        FlowerFound,
        ButterflyClicked,
        WateringHint,
        PotClicked,
        WateringClicked
    }

    public GameObject floweyBubble;
    public TextMeshProUGUI floweyText;

    private bool isBubbleOpen = false;

    void Start()
    {
        floweyBubble.SetActive(false);
        SetState(FloweyState.Start);
    }

    public void ToggleBubble()
    {
        isBubbleOpen = !isBubbleOpen;
        floweyBubble.SetActive(isBubbleOpen);
    }

    public void TriggerStartMessage() 
    { 
        SetState(FloweyState.Start); 
    }

    public void TriggerFlowerFoundMessage() 
    { 
        SetState(FloweyState.FlowerFound); 
    }

    public void TriggerWateringMessage() 
    { 
        SetState(FloweyState.WateringHint); 
    }

    public void SetState(FloweyState state)
    {
        switch (state)
        {
            case FloweyState.Start:
                floweyText.text =
                    "Hi there!\nMy name is Flowey the Flower, and I'll be your personal tour guide through my app. Thanks for downloading by the way!\nTo start, point your camera at the image to bring the hyacinth to life.";
                break;

            case FloweyState.ButterflyClicked:
                floweyText.text =
                    "Beautiful!\nI'll say, you're looking like a real pro in the garden, not bad at all!\n\nWell that's about it from me. Feel free to explore the scenary more if you wish, I'll still be here if you want to inspect my garden again. Untill next time, Flowey out!";
                break;

            case FloweyState.WateringHint:
                floweyText.text =
                    "Drag the watering can over the pot to help the flower grow!";
                break;
            
            case FloweyState.FlowerFound:
                floweyText.text =
                    "Well done!\nIsn't it beautiful? I sure think so!\n Explore the scenary around the hyacinth, maybe the watering can has something to say...";
                break;

            case FloweyState.PotClicked:
                floweyText.text = 
                    "Nice, now he has a friend!\n\nThe images shown are those of a hyacinth in nature with all his other friends! They come in aall shapes, colors and sizes. My favorite is the red one!\n\nFinally, try checking out what the butterfly has to say. I heard he knows a lot about hyacinths, how they're born, and how they grow.";
                break;

            case FloweyState.WateringClicked:
                floweyText.text =
                    "Awesome!\nLooks like our flowery friend could use some company. Try watering the pot so that our beautiful hyacinth isn't as lonely. Remember to use both fingers!";
                break;
        }

    }
}
