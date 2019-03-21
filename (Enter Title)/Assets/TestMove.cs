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
    }

    private bool cube1Clicked = false;
    private bool cube2Clicked = false;

    //make sure rigidbody is attached to the object before you freak the fuck out.
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Cube1" && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<TestMove>().enabled = false;
            _levelMasterRef.Level1();
        }

        if (other.gameObject.name == "Cube2" && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<TestMove>().enabled = false;
            _levelMasterRef.Level2();
        }

        if (other.gameObject.name == "Cube3" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("HERE");
            GetComponent<TestMove>().enabled = false;
            _levelMasterRef.Level3();
        }
    }
}
