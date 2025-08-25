using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRb : IMovable
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    public void Initialize(Rigidbody2D rigidbody, float initialMoveSpeed)
    {
        rb = rigidbody;
    }
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public void Move(Vector2 direction)
    {
        if (rb == null) return;
        
        rb.velocity = direction.normalized * MoveSpeed;
    }
    
}
