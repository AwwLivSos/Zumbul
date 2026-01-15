using UnityEngine;

public class PotGalleryManager : MonoBehaviour
{
    // Drag the "Canvas" or "GalleryPanel" into this slot in the Inspector
    public GameObject galleryUI; 

    void Start()
    {
        galleryUI.SetActive(false);
    }

    public void Toggle()
    {
        if (galleryUI != null)
        {
            galleryUI.SetActive(!galleryUI.activeSelf);
        }
    }
}