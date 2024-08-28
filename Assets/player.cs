using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0,0,7);

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0,10,0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0,-10,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-10,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(10,0,10);
        }
    }
}
