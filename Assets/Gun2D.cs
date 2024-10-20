using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;  // Use this if object pool is replaced
    public float bulletSpeed = 10f;

    [SerializeField] bool poolThisObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Convert mouse position from screen space to world space
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        mousePos.z = 0f; // Set z to zero for 2D

        // Calculate the direction from the gun to the mouse
        Vector2 direction = (mousePos - bulletSpawnPoint.position).normalized;

        // Declare the bullet variable once
        GameObject bullet;

        // Use object pool or instantiate a new bullet based on the condition
        if (poolThisObject)
        {
            bullet = ObjectPool.instance.GetPooledObject();
        }
        else
        {
            bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        }

        if (bullet != null)
        {
            // Set bullet's position and activate it
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.SetActive(true);

            // Initialize the bullet with the direction
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.Initialize(direction);
            }
        }
        else
        {
            Debug.Log("No Bullet Available from Object Pool");
        }
    }
}