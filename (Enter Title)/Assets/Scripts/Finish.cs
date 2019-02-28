using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject _cube1;
    public GameObject _cube2;
    public GameObject _cube3;
    public GameObject _cube4;
    public GameObject _cube5;
    public GameObject _cube6;
    public GameObject _cube7;
    public GameObject _cube8;
    public GameObject _cube9;
    public GameObject _cube10;
    public GameObject _cube11;
    public GameObject _cube12;
    public GameObject _cube13;
    public GameObject _cube14;

    public float thrust;

    public void FinishEx()
    {
        GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<BoxCollider>().enabled = false;

        _cube1.SetActive(true);
        _cube2.SetActive(true);
        _cube3.SetActive(true);
        _cube4.SetActive(true);
        _cube5.SetActive(true);
        _cube6.SetActive(true);
        _cube7.SetActive(true);
        _cube8.SetActive(true);
        _cube9.SetActive(true);
        _cube10.SetActive(true);
        _cube11.SetActive(true);
        _cube12.SetActive(true);
        _cube13.SetActive(true);
        _cube14.SetActive(true);

        _cube1.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube2.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube3.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube4.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube5.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube6.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube7.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube8.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube9.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube10.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube11.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube12.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube13.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
        _cube14.GetComponent<Rigidbody>().AddForce(Vector3.right * thrust);
    }
}
