using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.1f;
    
    [SerializeField] int moveSpeed = 10;
    [SerializeField] int boostedSpeed = 15;
    [SerializeField] int slowedSpeed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float steer = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        transform.Rotate(0, 0, -steer);
        transform.Translate(0, move, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Booster"))
        {
            moveSpeed = boostedSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowedSpeed;
    }
}
