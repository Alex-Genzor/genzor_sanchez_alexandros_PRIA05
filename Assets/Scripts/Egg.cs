using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Egg : MonoBehaviour
{
    [Header(" Physics settings ")] [SerializeField]
    private float bounceSpeed;
    private Rigidbody2D rig;
        
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerController player))
        {
            Bounce(collision.GetContact(0).normal);
            
        }
        
    }

    private void Bounce(Vector2 normal)
    {
        rig.velocity = normal * bounceSpeed;
        
    }
    
}