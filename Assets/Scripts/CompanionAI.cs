using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    [SerializeField] Transform targetPoint;

    public float movementSpeed = 2f;
    public float rotationSpeed = 2f;

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        //move companion to target position
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, movementSpeed * Time.deltaTime);
        //rotate companion towards target forward
        transform.rotation = Quaternion.Slerp(transform.rotation, targetPoint.rotation, rotationSpeed * Time.deltaTime);
    }
}
