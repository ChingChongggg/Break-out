using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(0, 0, horizontalInput) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}

public class PaddleBounciness : MonoBehaviour
{
    public float bounciness = 1.5f;

    private void Start()
    {
        Collider paddleCollider = GetComponent<Collider>();

        if (paddleCollider != null)
        {
            PhysicMaterial newMaterial = new PhysicMaterial();
            newMaterial.bounciness = bounciness;

            paddleCollider.material = newMaterial;
        }
    }
}