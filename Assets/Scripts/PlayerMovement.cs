using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float SprintSpeed = 7f;

    public LayerMask groundMask;
    private Vector3 moveVector;
    private float horizontal;
    private float vertical;
    private float currentSpeed;

    void Update()
    {
        OnInput();
        Movement();
        RotateTowardsMousePoint();
    }
    private void OnInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            currentSpeed = SprintSpeed;
        else
            currentSpeed = WalkSpeed;
    }
    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveVector = new Vector3(horizontal * currentSpeed * Time.deltaTime, 0, vertical * currentSpeed * Time.deltaTime);

        if (moveVector.magnitude > 1)
            moveVector.Normalize();

        transform.Translate(moveVector, Space.World);
    }
    private void RotateTowardsMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            transform.LookAt(hit.point);
        }
    }
}
