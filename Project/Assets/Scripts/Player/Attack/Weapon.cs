using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the firepoint to shoot.
/// </summary>
public class Weapon : MonoBehaviour
{
    // Public attributes
    public Transform firePoint;
    public GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    // Instantiate a bullet if firepoint position.
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
