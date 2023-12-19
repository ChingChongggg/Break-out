using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BouncingSphere : MonoBehaviour
{
    public float speed = 5f; 
    private bool isMovingDown = true;

    void Update()
    {
        if (isMovingDown)
        {
           
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            isMovingDown = false; 

            
            Vector3 normal = collision.contacts[0].normal;
            Vector3 reflection = Vector3.Reflect(transform.up, normal);

            
            transform.up = reflection;
        }
    }
}
public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 8f;
    private Vector3 direction;
    private Transform paddle;

    private void Update()
    {
        if (transform.position.y < -6)
        {
            transform.position = new Vector3(0, 5, 0);
        }

    }

    void Start()
    {
        
        paddle = GameObject.FindGameObjectWithTag("Paddle").transform;


        direction = (paddle.position - transform.position).normalized;
        GetComponent<Rigidbody>().velocity = direction * initialSpeed;
    }

   


  

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
           
            float hitFactor = (transform.position.z - collision.transform.position.z) / (collision.collider.bounds.size.z * 0.5f);

          
            direction = new Vector3(-direction.x, 0f, hitFactor).normalized;

           
            GetComponent<Rigidbody>().velocity = direction * initialSpeed;
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {

            Destroy(collision.gameObject);
        }
    }
}
