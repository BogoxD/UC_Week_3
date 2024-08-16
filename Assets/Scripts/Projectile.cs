using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    private float projectileForce;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(projectileForce * transform.forward * Time.deltaTime, ForceMode.VelocityChange);
    }
    public void SetProjectileSpeed(float speed)
    {
        projectileForce = speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //check if is colliding with any object on the Enemy Layer
        if (collision.gameObject.layer == 7)
            gameObject.SetActive(false);
    }
}
