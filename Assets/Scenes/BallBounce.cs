using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public float initialSpeed = 8f;

    private Vector3 direction;

    
    void Start()
    {
        direction = Vector3.forward + Vector3.right; 
        direction = direction.normalized;
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
        else if (collision.gameObject.CompareTag("Wall"))
        {

            Vector3 normal = collision.contacts[0].normal;

       
            float dotProduct = Vector3.Dot(direction, normal);

            direction -= 2f * dotProduct * normal;
            direction = direction.normalized;


            GetComponent<Rigidbody>().velocity = direction * initialSpeed;
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {
            
            Destroy(collision.gameObject);

            Vector3 normal = collision.contacts[0].normal;


            float dotProduct = Vector3.Dot(direction, normal);
            direction -= 2f * dotProduct * normal;
            direction = direction.normalized;

           
            GetComponent<Rigidbody>().velocity = direction * initialSpeed;
        }
    }
}