using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelbaboy : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;
    public float fireRate = 2f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
    }
}
