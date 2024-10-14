using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;   
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public Transform cannon;

    void Update() {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);
        // transform.Translate(0, 0, speed * Time.deltaTime);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            // Rotaciona o canhão para cima
            cannon.RotateAround(cannon.position, cannon.right, -30 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            // Rotaciona o canhão para baixo
            cannon.RotateAround(cannon.position, cannon.right, 30 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
