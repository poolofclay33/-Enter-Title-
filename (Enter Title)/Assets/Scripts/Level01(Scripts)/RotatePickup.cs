using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePickup : MonoBehaviour
{
    public bool _collected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = false;

            _collected = true;
        }
    }

    private Vector3 MovingDirection = Vector3.up;

    void Update()
    {
        gameObject.transform.Translate(MovingDirection * Time.smoothDeltaTime);

        if (gameObject.transform.position.y > 0.50f)
        {
            MovingDirection = Vector3.down * 0.5f;
        }
        else if (gameObject.transform.position.y < 0)
        {
            MovingDirection = Vector3.up * 0.5f;
        }
    }

    //float speed = 5f;
    ////adjust this to change how high it goes
    //float height = 0.5f;

    //void Update()
    //{
    //    //get the objects current position and put it in a variable so we can access it later with less code
    //    Vector3 pos = transform.position;
    //    //calculate what the new Y position will be
    //    float newY = Mathf.Sin(Time.time * speed);
    //    //set the object's Y to the new calculated Y
    //    //transform.position = new Vector3(pos.x, newY, pos.z) * height;
    //}
}
