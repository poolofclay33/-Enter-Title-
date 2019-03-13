using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 20)]
    public float jumpVelocity;

    public bool grounded = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            if(GetComponent<Movement>()._gravity == false)
            {
                GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
            }
            else
            {
                GetComponent<Rigidbody>().velocity = Vector3.down * jumpVelocity;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
