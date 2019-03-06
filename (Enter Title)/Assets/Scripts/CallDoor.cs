using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallDoor : MonoBehaviour
{
    public GameObject _door;

    public void OpenDoor()
    {
        _door.GetComponent<Animator>().Play("OpenDoor(Tutorial)");
    }
}
