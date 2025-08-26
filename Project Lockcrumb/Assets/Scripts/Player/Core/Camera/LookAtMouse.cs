using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Camera mainCamera;

    public Vector2 MouseDir { get; private set; }

    void Awake()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // For 2D, ignore the z axis and use x/y
        Vector2 direction = worldMousePosition - transform.position;
        direction.Normalize();

        MouseDir = direction;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
