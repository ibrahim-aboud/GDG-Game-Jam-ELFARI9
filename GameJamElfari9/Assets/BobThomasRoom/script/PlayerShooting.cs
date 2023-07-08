using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootFrequency;
    private float lastShootTime = 0.1f;
    public float freezeTime;
    public float shootSpeed;
    public float shootDistance = 10f;

    void Update()
    {
        lastShootTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && lastShootTime >= freezeTime)
        {
            Debug.Log("The shot");
            Shoot();
        }
    }

    void Shoot()
    {
        lastShootTime = 0f;

        Vector3 targetPosition = transform.position + transform.forward * shootDistance;

        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();

        Vector3 direction = targetPosition - bulletSpawnPoint.position;
        direction.Normalize();

        bulletRigidbody.velocity = direction * shootSpeed;
    }
}
