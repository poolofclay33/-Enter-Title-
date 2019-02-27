using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed;
    public float fallMulti = 2.5f;
    public float lowJump = 2f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //movement 
        transform.Translate(Time.deltaTime * speed, 0, 0);

        Vector3 pos = transform.position;

        pos.z = Mathf.Clamp(transform.position.z, -1, 1);

        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(transform.position.z == 1)
            {
                //
            } 
            else 
            {
                transform.Translate(0f, 0f, 1f);
                Mathf.RoundToInt(transform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.z == -1)
            {
                //
            }
            else
            {
                transform.Translate(0f, 0f, -1f);
            }
        }

        //jump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJump - 1) * Time.deltaTime;
        }
    }
}
