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

    // Reference to PlayerInput component
    private PlayerInput playerInput;
    private InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        if (moveAction == null)
        {
            Debug.LogError("Move action not found in Input System.");
        }
    }

    void Update()
    {
        ReadInput();
        Move();
        Debug.DrawRay(transform.position, movementInput * 2f, Color.red);
    }

    private void ReadInput()
    {
        movementInput = moveAction.ReadValue<Vector2>();
    }

    public void Move()
    {
        if (movementInput != Vector2.zero)
        {
            transform.position += (Vector3)(movementInput.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
