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
    public static int damage = 40;
    public float attackRate = 4f;

    private float nextShootTime = 0f;

    private void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {            
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time >= nextShootTime)
            {
                nextShootTime = Time.time + 1 / attackRate;
                Shoot();
            }
        }
    }


    // Instantiate a bullet if firepoint position.
    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("BulletSound");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


    private void LoadData()
    {
        SettingsData data = new SettingsData();
        if (data != null)
        {
            attackRate = data.playerAttackRate;
            damage = data.playerDamage;
        }
    }
}
