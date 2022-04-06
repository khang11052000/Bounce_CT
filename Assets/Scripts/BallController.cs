using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public float movement;
    public float speed  = 3f;
    public float jumbForce  = 5f;
    
    public Animator animator;

    private float _maxVel = 0f;
    private Rigidbody2D _rigibody;
    private float _elastic = 0f;
    private bool _isPress = false;
    private bool _isCollisionWall;
    private bool _isballBig = false;

    private void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    

    private void Update()
    {
        Move();
        ReduceSpeed();

        if (_rigibody.velocity.y > _elastic)
        {
            _elastic = _rigibody.velocity.y;
        }
        
        //Debug.Log(_rigibody.velocity.y);
        
        animator.SetBool("Live", GameManager.Instance.isLive);
        animator.SetBool("Big", _isballBig);
    }

    private void ReduceSpeed()
    {
        if (_isPress == false)
        {
            var vel_X = _rigibody.velocity.x;
            vel_X = vel_X * 0.993f;
            _rigibody.velocity = new Vector2(vel_X, _rigibody.velocity.y);
            //_rigibody.velocity = _rigibody.velocity * 0.5f;
        }
    }

    public void Move()
    {
        movement = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        _rigibody.velocity = new Vector2(movement * speed, _rigibody.velocity.y);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigibody.velocity.y) < 0.001f)
        {
            _rigibody.AddForce(new Vector2(0, jumbForce), ForceMode2D.Impulse);
        }
    }

    public void MoveLeft()
    {
        _isPress = true;
        _rigibody.velocity += Vector2.left * speed;
        //Debug.Log(_rigibody.velocity);
    }

    public void MoveRight()
    {
        _isPress = true;
        _rigibody.velocity += Vector2.right * speed;
    }

    public void MoveUp()
    {
        
        if (_isCollisionWall == true)
        {
            _rigibody.AddForce(new Vector2(0, (jumbForce - _elastic)), ForceMode2D.Impulse);
            Debug.Log(2);
        }
        
        
        // if ((Mathf.Abs(_rigibody.velocity.y) > 0.001f) && (_isCollisionWall == true))
        // {
        //     _rigibody.AddForce(new Vector2(0, (jumbForce - _elastic)), ForceMode2D.Impulse);
        //     Debug.Log(2);
        // }
        //
        // //(Mathf.Abs(_rigibody.velocity.y) < 0.001f)|| 
        // if (Mathf.Abs(_rigibody.velocity.y) < 0.001f)
        // {
        //     _rigibody.AddForce(new Vector2(0, jumbForce), ForceMode2D.Impulse);
        //     Debug.Log(1);
        // }
        
    }

    
    
    public void OnMouseUp()
    {
        _isPress = false;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if ((collision2D.collider.tag == "Enemy") && (GameManager.Instance.IntLive != 0) )
        {
            GameManager.Instance.Die();
            Invoke("revival", 2f);
            GameManager.Instance.revival();
            GameManager.Instance.EndTimer();
            GameManager.Instance.BeginTimer();
            GameManager.Instance.GameOver();
        }
        
        if ((collision2D.collider.tag == "Enemy") && (GameManager.Instance.IntLive == 0) )
        {
            GameManager.Instance.GameOver();
            GameObject.Destroy(gameObject);
        }

        if (collision2D.collider.tag == "Wall")
        {
            _isCollisionWall = true;
            _elastic = _elastic * 0.6f;
            _rigibody.AddForce(new Vector2(0, _elastic), ForceMode2D.Impulse);
        }
        
        if (collision2D.collider.tag == "Item")
        {
            _isballBig = true;
        }

        //Debug.Log(collision2D.collider.tag);
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.collider.tag == "Wall")
        {
            _isCollisionWall = false;
        }
    }
}
