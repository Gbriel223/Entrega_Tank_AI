using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShell : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 0f;
    float mass = 1f;
    float force = 20f;
    float acceleration;
    float drag = 1f;
    float ySpeed = 0f;
    float gravity = -9.8f;
    float gravityAcceleration = 0f;
    public float damage = 15.0f;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
            TankHealth tankHealth = col.gameObject.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                // Aplica dano ao tanque
                tankHealth.TakeDamage(damage);
                Debug.Log("DEU DANO");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        acceleration = force / mass;
        speed += acceleration;
        gravityAcceleration = gravity / mass;
    }
    private void Update()
    {
        speed *= (1 - Time.deltaTime * drag);
        ySpeed += gravityAcceleration * Time.deltaTime * 0.01f;
        transform.Translate(0, ySpeed, speed * Time.deltaTime);

    }
}


