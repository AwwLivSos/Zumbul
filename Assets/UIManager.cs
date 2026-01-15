using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI bodyText;

    void Start()
    {
        if (infoPanel == null)
            Debug.LogError("UIManager: infoPanel NOT assigned", this);

        infoPanel.SetActive(false);
    }


    public void ShowButterfly()
    {
        Debug.Log("UIManager instance: " + gameObject.name);
        Debug.Log("infoPanel is null? " + (infoPanel == null));

        infoPanel.SetActive(true);
        titleText.text = "Hyacinth in Nature";
        bodyText.text =
            "Hyacinths grow in Mediterranean regions.\n\n" +
            "They prefer sunlight and well-drained soil.\n\n" +
            "Their scent is strongest in early spring.";
    }

    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }
}
