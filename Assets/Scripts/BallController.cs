using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float movement;
    public float speed  = 10f;
    public float jumbForce  = 5f;

    private Rigidbody2D _rigibody;

    private void Start()
    {
        _rigibody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigibody.velocity.y) < 0.001f)
        {
            _rigibody.AddForce(new Vector2(0, jumbForce), ForceMode2D.Impulse);
        }
    }
    
}
