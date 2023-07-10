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
    public AudioClip shootSoundClip; // Sound clip for player shooting
    private AudioSource audioSource;

void Start()
    {
        // Create an AudioSource component if not already attached
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        lastShootTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && lastShootTime >= freezeTime)
        {
            Debug.Log("The shot");
            Shoot();
            // Play shoot sound
            if (shootSoundClip != null)
            {
                audioSource.PlayOneShot(shootSoundClip);
            }
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
