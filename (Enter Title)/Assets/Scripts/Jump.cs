using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;

    public bool grounded = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && grounded == true)
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            grounded = false;
        }
    }
}
