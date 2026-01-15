using UnityEngine;
using System.Collections;

public class WateringLogic : MonoBehaviour
{
    public ParticleSystem waterParticles;
    public GameObject flowerToGrow; // Drag the Hyacinth here
    public float growDuration = 5.0f;
    
    private bool isGrowing = false;
    private bool hasGrown = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if we hit the pot and haven't grown the flower yet
        if (other.gameObject.name == "saksijaDobra") 
        {
            waterParticles.Play();
            
            if (!hasGrown && !isGrowing)
            {
                StartCoroutine(GrowFlowerRoutine());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "saksijaDobra")
        {
            waterParticles.Stop();
        }
    }

    IEnumerator GrowFlowerRoutine()
    {
        isGrowing = true;

        // 1. Wait for 1.5 seconds after water starts
        yield return new WaitForSeconds(1.5f);

        float timer = 0;
        Vector3 startScale = Vector3.zero;
        Vector3 endScale = new Vector3(1, 1, 1); // Adjust if your flower needs to be bigger/smaller

        // 2. Gradually increase scale over 5 seconds
        while (timer < growDuration)
        {
            timer += Time.deltaTime;
            // This math smoothly moves from startScale to endScale
            flowerToGrow.transform.localScale = Vector3.Lerp(startScale, endScale, timer / growDuration);
            yield return null; 
        }

        // 3. Ensure it's exactly at the final scale
        flowerToGrow.transform.localScale = endScale;
        isGrowing = false;
        hasGrown = true;
    }
}