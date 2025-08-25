using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;

    private Vector2 movementInput;


    #region Input System
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction shootAction;
    #endregion

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        ReadInput();
        OnMove();
        Debug.DrawRay(transform.position, movementInput * 2f, Color.red);
    }

    private void ReadInput()
    {
        movementInput = moveAction.ReadValue<Vector2>();

        if (shootAction.triggered)
        {
            OnShoot();
        }
    }
    public void OnShoot()
    {
        Debug.Log("Shoot action triggered");
    }
    public void OnMove()
    {
        if (movementInput != Vector2.zero)
        {
            transform.position += (Vector3)(movementInput.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
