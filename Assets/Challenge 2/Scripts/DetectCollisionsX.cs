using UnityEngine;
using System;

public class DetectCollisionsX : MonoBehaviour
{
    //collect ball event
    public static event Action collectBall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            collectBall();
            Destroy(gameObject);
        }
    }
}
