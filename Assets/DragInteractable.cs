using UnityEngine;

public class DragInteractable : MonoBehaviour
{
    private bool isDragging = false;
    private Camera mainCamera;
    private float dragDistance;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // TOUCH (Android)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            HandleTouch(touch.position, touch.phase);
        }

        // MOUSE (Editor)
        if (Input.GetMouseButtonDown(0))
            HandleTouch(Input.mousePosition, TouchPhase.Began);

        if (Input.GetMouseButton(0))
            HandleTouch(Input.mousePosition, TouchPhase.Moved);

        if (Input.GetMouseButtonUp(0))
            HandleTouch(Input.mousePosition, TouchPhase.Ended);
    }

    void HandleTouch(Vector2 screenPos, TouchPhase phase)
    {
        Ray ray = mainCamera.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (phase == TouchPhase.Began)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    dragDistance = Vector3.Distance(
                        mainCamera.transform.position,
                        transform.position
                    );
                }
            }
        }

        if (phase == TouchPhase.Moved && isDragging)
        {
            Vector3 newPos = mainCamera.ScreenToWorldPoint(
                new Vector3(screenPos.x, screenPos.y, dragDistance)
            );
            transform.position = newPos;
        }

        if (phase == TouchPhase.Ended)
        {
            isDragging = false;
        }
    }
}
