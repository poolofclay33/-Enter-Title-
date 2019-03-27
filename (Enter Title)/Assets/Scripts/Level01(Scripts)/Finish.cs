using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public static Finish _instance;
    public static bool _level1Done = false;

    public Material _highlight;

    public ParticleSystem _particle;

    public GameObject _gameManager;

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

    public static bool[] _levelFinished = new bool[15];

    public void FinishEx()
    {
        GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<BoxCollider>().enabled = false;

        _particle.Play();

        StartCoroutine("SlowTime");

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

        _cube1.GetComponent<Renderer>().material = _highlight;
        _cube2.GetComponent<Renderer>().material = _highlight;
        _cube3.GetComponent<Renderer>().material = _highlight;
        _cube4.GetComponent<Renderer>().material = _highlight;
        _cube5.GetComponent<Renderer>().material = _highlight;
        _cube6.GetComponent<Renderer>().material = _highlight;
        _cube7.GetComponent<Renderer>().material = _highlight;
        _cube8.GetComponent<Renderer>().material = _highlight;
        _cube9.GetComponent<Renderer>().material = _highlight;
        _cube10.GetComponent<Renderer>().material = _highlight;
        _cube11.GetComponent<Renderer>().material = _highlight;
        _cube12.GetComponent<Renderer>().material = _highlight;
        _cube13.GetComponent<Renderer>().material = _highlight;
        _cube14.GetComponent<Renderer>().material = _highlight;

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

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if(sceneName == "Level01")
        {
            _levelFinished[0] = true;

            ES3.Save<bool>("Level01", true);
        }

        if (sceneName == "Level02")
        {
            _levelFinished[1] = true;

            ES3.Save<bool>("Level02", true);
        }

        if (sceneName == "Level03")
        {
            _levelFinished[2] = true;

            ES3.Save<bool>("Level03", true);
        }

        if (sceneName == "Level04")
        {
            _levelFinished[3] = true;

            ES3.Save<bool>("Level04", true);
        }
    }

    IEnumerator SlowTime()
    {
        //CameraShaker.Instance.ShakeOnce(3f, 1f, .1f, 3f);

        //Time.timeScale = 0.2f;

        yield return new WaitForSeconds(0.4f);

        //Time.timeScale = 1.0f;
    }
}
