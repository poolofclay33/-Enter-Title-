using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public LevelMaster _levelMasterRef;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0.0f, 0.0f, 16.0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(0.0f, 0.0f, -16.0f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-16.0f, 0.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(16.0f, 0.0f, 0.0f);
        }

        if (cube1Clicked && Input.GetKeyDown(KeyCode.Space))
        {
            _levelMasterRef.Level1();
        }
    }

    private bool cube1Clicked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube1")
        {
            cube1Clicked = true;
        }

        if (other.gameObject.name == "Cube2")
        {
            cube2Clicked = true;
        }
    }
}
