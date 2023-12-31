using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField]
    float speed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * speed;
        }
    }


}
