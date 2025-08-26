using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
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

    public Weapon currentWeapon;


    #region Input System
    private InputAction moveAction;
    private InputAction shootAction;
    private InputAction reloadAction;
    #endregion

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        reloadAction = InputSystem.actions.FindAction("Reload");
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
        if (reloadAction.triggered)
        {
            currentWeapon.Reload();
        }

    }
    public void OnShoot()
    {
        currentWeapon.Shoot();
    }
    public void OnMove()
    {
        if (movementInput != Vector2.zero)
        {
            transform.position += (Vector3)(movementInput.normalized * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
