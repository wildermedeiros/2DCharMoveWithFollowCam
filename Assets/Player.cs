using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    
    Vector2 axisValue;
    
    private void FixedUpdate() 
    {
        Move();
    }

    private void Move()
    {
        if(axisValue.sqrMagnitude < 0.01) { return; }

        var scaledMovement = speed * Time.deltaTime;

        var newPosition = new Vector3(axisValue.x * scaledMovement, axisValue.y * scaledMovement, 0f);

        transform.position += newPosition;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        axisValue = context.ReadValue<Vector2>();
    }
}
