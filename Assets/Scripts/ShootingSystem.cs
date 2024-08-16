using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject[] projectilesPrefabArray;


    private GameObject projectilePrefab;
    public float projectileSpeed = 5f;

    private void Start()
    {
        //initialize projectilePrefab with first element of array
        projectilePrefab = projectilesPrefabArray[0];
    }
    void Update()
    {

        ProjectileSelection();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootProjectile();
        }

    }
    private void ProjectileSelection()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            projectilePrefab = projectilesPrefabArray[0];
        if (Input.GetKeyDown(KeyCode.Alpha2))
            projectilePrefab = projectilesPrefabArray[1];
        if (Input.GetKeyDown(KeyCode.Alpha3))
            projectilePrefab = projectilesPrefabArray[2];

    }
    private void ShootProjectile()
    {
        GameObject projecitle = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
        projecitle.GetComponent<Projectile>().SetProjectileSpeed(projectileSpeed);
    }
}
