using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    //private Rigidbody2D _rb2D;

    public GameObject GoldRing;

    // private void Start()
    // {
    //     _rb2D = GetComponent<Rigidbody2D>();
    // }
    

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.tag == "Ball")
        {
            GoldRing.SetActive(false);
        }
        
        //Debug.Log(collision2D);
    }
}
