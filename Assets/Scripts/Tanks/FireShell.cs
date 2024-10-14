using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShell : MonoBehaviour {

    public GameObject bullet;
    public GameObject turret;
    public GameObject enemy;
    public Transform cannon;
    public float projectileSpeed = 20.0f;
    public Transform player;
    public float shootingDistance = 15f;
    void CreateBullet() {

        Instantiate(bullet, turret.transform.position, turret.transform.rotation);
    }

    void Update() {


        float distanceToPlayer = Vector3.Distance(cannon.position, player.position);
        if (distanceToPlayer <= shootingDistance)
        {
            ShootAtPlayer();
        }

        
    }
    void ShootAtPlayer()
    {
        // Instancia a bala na posição do canhão
        GameObject shell = Instantiate(bullet, cannon.position, cannon.rotation);
        // Define a velocidade da bala
        Rigidbody rb = shell.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = cannon.forward * projectileSpeed; // Atira na direção do canhão
        }
    }

    Vector3 CalculateTrajectory() {

        Vector3 p = enemy.transform.position - this.transform.position;
        Vector3 v = enemy.transform.forward * enemy.GetComponent<Drive>().speed;
        float s = bullet.GetComponent<MoveShell>().speed;

        float a = Vector3.Dot(v, v) - s * s;
        float b = Vector3.Dot(p, v);
        float c = Vector3.Dot(p, p);
        float d = b * b - a * c;

        if (d < 0.1f) return Vector3.zero;

        float sqrt = Mathf.Sqrt(d);
        float t1 = (-b - sqrt) / c;
        float t2 = (-b + sqrt) / c;

        float t = 0.0f;
        if (t1 < 0.0f && t2 < 0.0f) return Vector3.zero;
        else if (t1 < 0.0f) t = t2;
        else if (t2 < 0.0f) t = t1;
        else {

            t = Mathf.Max(new float[] { t1, t2 });
        }
        return t * p + v;
    }
}
