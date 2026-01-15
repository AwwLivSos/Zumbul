using UnityEngine;
using UnityEngine.EventSystems;
using Lean.Touch;

public class LeanTouchUIBlocker : MonoBehaviour
{
    private LeanDragTranslate drag;

    void Awake()
    {
        drag = GetComponent<LeanDragTranslate>();
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            drag.enabled = false;
        }
        else
        {
            drag.enabled = true;
        }
    }
}
