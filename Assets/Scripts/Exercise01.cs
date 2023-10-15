using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise01 : MonoBehaviour
{
    private Vector3 gridPosition;
    private Vector3 startGridPosition;
    private Vector3 gridMoveDirection;

    private bool rightUp, rightDown, leftUp, leftDown;

    private float gridMoveTimer;
    private float gridMoveTimerMax = 1f; // La serpiente se moverá a cada segundo

    private void Awake()
    {
        startGridPosition = new Vector3(0, 0);
        gridPosition = startGridPosition;

        gridMoveDirection = new Vector3(1, 1);
    }
    private void Update()
    {
        HandleGridMovement();
        HandleMoveDirection();
    }
    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;

            gridPosition += gridMoveDirection;
        }
        transform.position = new Vector3(gridPosition.x, gridPosition.y);
    }
    
    private void HandleMoveDirection()
    {
        rightUp = Input.GetKeyDown(KeyCode.E);
        rightDown = Input.GetKeyDown(KeyCode.D);
        leftUp = Input.GetKeyDown(KeyCode.Q);
        leftDown = Input.GetKeyDown(KeyCode.A);

        // Cambio dirección hacia arriba
        if (rightUp == true && gridMoveDirection != new Vector3(-1, -1)) // (E o Diagonal derecha arriva)
        {
            // Cambio la dirección hacia arriba (1,1)
            gridMoveDirection = new Vector3(1, 1);
            Debug.Log("E");
        }
        if (rightDown == true && gridMoveDirection != new Vector3(-1, 1)) // (D o Diagonal derecha abajo)
        {
            gridMoveDirection = new Vector3(1, -1);
            Debug.Log("D");
        }
        if (leftUp == true && gridMoveDirection != new Vector3(1, -1)) // (Q o Diagonal izquierda arriva)
        {
            gridMoveDirection = new Vector3(-1, 1);
            Debug.Log("Q");
        }
        if (leftDown == true && gridMoveDirection != new Vector3(1, 1)) // (A o Diagonal izquierda abajo)
        {
            gridMoveDirection = new Vector3(-1, -1);
            Debug.Log("A");
        }
    }
}
