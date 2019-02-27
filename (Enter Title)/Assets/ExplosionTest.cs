using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTest : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float radius = 5.0F;
    public float power = 10.0F;

    public void Explode()
    {
        Debug.Log("DSLKFJEKLJEFKL");

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

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

        //_cube1.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube2.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube3.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube4.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube5.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube6.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube7.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube8.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube9.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube10.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube11.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube12.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube13.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);
        //_cube14.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * thrust);

        //Vector3 explosionPos = transform.position;

        //_cube1.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube2.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube3.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube4.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube5.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube6.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube7.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube8.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube9.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube10.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube11.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube12.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube13.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
        //_cube14.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);

    }
}
