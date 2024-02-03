using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    Rigidbody2D rb;
    public float gravityScale = 9.82f;
    public float shotspeed = 30f;
    public float angle;

    public CannonController controller;
    public void ShootBall()
    {
        angle = controller.GetCannonAngle();
        shotspeed = controller.GetCannonPower();
        rb.totalTorque = 0;
        rb.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        rb.gravityScale = gravityScale;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rb.velocity = transform.right * shotspeed;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    private void Update()
    {
        if (transform.position.y < 0)
        {

            Debug.Log(transform.position.x);
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            rb.totalTorque = 0;
            transform.position = Vector3.zero;

        }
    }
}
