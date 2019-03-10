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

    public LevelMaster _levelMasterRef;

    private void Start()
    {
        LoadPLayer();
    }

    private void Update()
    {
        if(input == true)
        {
            if(Input.GetKey(KeyCode.W))
            {
                StartCoroutine("moveUp");
                input = false;
            }

            if (Input.GetKey(KeyCode.S))
            {
                StartCoroutine("moveDown");
                input = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                StartCoroutine("moveLeft");
                input = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                StartCoroutine("moveRight");
                input = false;
            }
        }

        if(cube1Clicked && Input.GetKeyDown(KeyCode.Space))
        {
            SavePlayer();
            _levelMasterRef.Level1();
        }
    }

    IEnumerator moveUp()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveDown()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        input = true;
    }

    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            player.transform.RotateAround(right.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = player.transform.position;
        input = true;
    }

    private bool cube1Clicked = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Cube1")
        {
            cube1Clicked = true;
        }
    }

    public void SavePlayer()
    {
        SavingLoading.SavePlayer(this);
    }

    public void LoadPLayer()
    {
        PlayerData data = SavingLoading.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }
}
