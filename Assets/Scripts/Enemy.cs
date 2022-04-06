using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _intTurn = 1;
    private float _speed = 3;
    private Rigidbody2D _rb2D;
    private float velX = 0;
    
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        velX += _speed * _intTurn * Time.deltaTime;
        _rb2D.velocity = new Vector2( velX, _rb2D.velocity.y * 0); 
        //Debug.Log(_rb2D.velocity.x);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Wall")
        {
            _intTurn *= -1;
            velX = 0;
        }
        
    }
}
