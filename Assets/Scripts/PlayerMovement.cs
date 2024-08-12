using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5f;

    public LayerMask groundMask;
    private Vector3 moveVector;
    private float horizontal;
    private float vertical;

    void Update()
    {
        Movement();
        RotateTowardsMousePoint();
    }
    private void Movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveVector = new Vector3(horizontal * Speed * Time.deltaTime, 0, vertical * Speed * Time.deltaTime);

        if (moveVector.magnitude > 1)
            moveVector.Normalize();

        transform.Translate(moveVector);
    }
    private void RotateTowardsMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            transform.LookAt(hit.point);
        }
    }
}
