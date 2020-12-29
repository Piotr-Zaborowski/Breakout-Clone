using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 20f;
    private new Rigidbody rigidbody;
    private Vector3 velocity;
    new Renderer renderer;



    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        Invoke("LaunchBall",0.5f);
    }

    void LaunchBall()
    {
        rigidbody.velocity = Vector3.up * speed; 
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
        velocity = rigidbody.velocity;
        if(!renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }


}
