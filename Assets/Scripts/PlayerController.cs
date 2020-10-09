using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;
    
    public float horizontalBoundary;
    public float horizontalSpeed;
    public float maxSpeed;
    private Rigidbody2D m_rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

    private void _FireBullet()
    {
        if (Time.frameCount % 40 == 0)
        {
            bulletManager.GetBullet(transform.position);
        }
    }
    private void _Move()
    {
        var direction = 0.0f;

        foreach(var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            
            if(worldTouch.x>transform.position.x)
            {
                direction = 1.0f;
            }

            if(worldTouch.x < transform.position.x)
            {
                direction = -1.0f;
            }

        }


        if ((Input.GetAxis("Horizontal") >= 0.1f))
        {
            direction = 1.0f;
        }

        if ((Input.GetAxis("Horizontal") <= -0.1f))
        {
            direction = -1.0f;
        }

        Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
        m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
        m_rigidBody.velocity *= 0.99f;

    }

    private void _CheckBounds()
    {
       if(transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
        }

        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
        }
    }
}
