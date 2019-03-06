using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectCube : MonoBehaviour
{
    private Vector3 offset;

    public GameObject player;

    public GameObject center;

    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;

    public int step = 9;

    public float speed = (float)0.01;

    bool input = true;

    IEnumerator moveUp()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
    }
}
