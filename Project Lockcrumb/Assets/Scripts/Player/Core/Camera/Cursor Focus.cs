using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFocus : MonoBehaviour
{
    public Transform player;
    public Camera mainCamera;
    [Header("Mouse Bias")]
    public float maxRadius = 6f;
    public float smoothTime = 0.06f;

    private Vector3 _velocity = Vector3.zero;


    void Reset()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (!player || !mainCamera) return;

        Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = player.position.z;

        Vector3 dir = mouseWorld - player.position;
        if (dir.sqrMagnitude > maxRadius * maxRadius)
        {
            dir = dir.normalized * maxRadius;
        }
        Vector3 targetPosition = player.position + dir;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
    }
}
