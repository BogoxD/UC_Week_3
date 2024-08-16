using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerX : MonoBehaviour
{
    public Slider staminaBar;
    public GameObject dogPrefab;

    public float targetTime = 2f;

    private bool canShoot = true;
    private float maxStamina = 100f;

    private void Start()
    {
        SetStaminaBar(maxStamina);
    }
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            SetStaminaBar(0);
        }
        else
        {
            AddToStaminaBar(targetTime / 2);

            if (staminaBar.value >= 100)
                canShoot = true;
        }
    }
    private void SetStaminaBar(float ammount)
    {
        staminaBar.value = ammount;
    }
    private void AddToStaminaBar(float ammount)
    {
        staminaBar.value += ammount;
    }


}
