using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChingChong : MonoBehaviour
{
    public class BallController : MonoBehaviour
    {
        public float speed = 5f; 

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.forward * speed; 
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Paddle"))
            {
                
                float hitPosition = (transform.position.z - collision.transform.position.z) / collision.collider.bounds.size.z;
                Vector3 direction = new Vector3(0, 0, hitPosition).normalized;
                rb.velocity = direction * speed;
            }
            else if (!collision.gameObject.CompareTag("Wall"))
            {
                
                Vector3 normal = collision.contacts[0].normal;
                Vector3 reflect = Vector3.Reflect(rb.velocity, normal);
                rb.velocity = reflect.normalized * speed;
            }
        }
    }

}
