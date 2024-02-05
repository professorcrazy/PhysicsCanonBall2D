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
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
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
    private void Update()
    {
        if (transform.position.y < 0)
        {
            Debug.Log("Ball RB x:" + (transform.position.x*10f).ToString("00.0") + " y:" + transform.position.y.ToString());
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            rb.totalTorque = 0;
            transform.position = Vector3.zero;

        }
    }
}
