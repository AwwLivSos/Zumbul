using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TapInteractable : MonoBehaviour
{
    public enum InteractableType
    {
        butterfly,
        kantica,
        saksijaDobra
    }

    public InteractableType type;

    // Timer variables for the watering can double-tap
    private float lastTapTime = 0f;
    private const float doubleTapThreshold = 0.3f; // Max time between taps

    void OnEnable() { EnhancedTouchSupport.Enable(); }
    void OnDisable() { EnhancedTouchSupport.Disable(); }

    void Update()
    {
        foreach (var t in Touch.activeTouches)
        {
            if (t.phase == UnityEngine.InputSystem.TouchPhase.Ended)
            {
                DoRaycast(t.screenPosition);
            }
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            DoRaycast(mousePos);
        }
    }

    void DoRaycast(Vector2 screenPosition)
    {
        var cam = Camera.main;
        if (cam == null) return;

        Ray ray = cam.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var interactable = hit.collider.GetComponentInParent<TapInteractable>();
            if (interactable == this)
            {
                HandleTap();
            }
        }
    }

    void HandleTap()
    {
        // SPECIFIC LOGIC FOR WATERING CAN
        if (type == InteractableType.kantica)
        {
            float timeSinceLastTap = Time.time - lastTapTime;
            
            if (timeSinceLastTap <= doubleTapThreshold)
            {
                // It was a double tap!
                Debug.Log("DOUBLE TAPPED: " + type);
                InteractionManager.Instance.OnObjectTapped(type);
                lastTapTime = 0f; // Reset so triple-tap doesn't trigger it twice
            }
            else
            {
                // First tap, just record the time
                lastTapTime = Time.time;
                Debug.Log("First tap on can... waiting for second.");
            }
        }
        else
        {
            // NORMAL LOGIC FOR EVERYTHING ELSE
            Debug.Log("SINGLE TAPPED: " + type);
            InteractionManager.Instance.OnObjectTapped(type);
        }
    }
}