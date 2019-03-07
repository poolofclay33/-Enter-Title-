using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaster : MonoBehaviour
{
    public Material _yellow;
    public Material _blue;

    public GameObject _cube1;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1()
    {
        _cube1.GetComponent<Renderer>().material = _yellow;
        //_cube1.GetComponentInChildren<ParticleSystem>().Play();
        //SceneManager.LoadScene("Level01");

        Debug.Log("MADEIt');");
    }

    public void TestMat()
    {
        _cube1.GetComponent<Renderer>().material = _blue;
    }
}
