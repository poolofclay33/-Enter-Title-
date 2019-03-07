using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMaster : MonoBehaviour
{
    public Material _yellow;
    public Material _blue;

    public GameObject _cube1;
    public GameObject _playerCube;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Start()
    {
        _playerCube.GetComponent<LevelSelectCube>().enabled = false;
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().Play("BeginLevelSelect");
        yield return new WaitForSeconds(4.5f);
        _playerCube.GetComponent<LevelSelectCube>().enabled = true;
    }

    public void Level1()
    {
        GetComponent<Animator>().enabled = false;

        _cube1.GetComponent<Renderer>().material = _yellow;
        //_cube1.GetComponentInChildren<ParticleSystem>().Play();
        //SceneManager.LoadScene("Level01");
        //_cube1.GetComponent<MeshRenderer>().material = _yellow;
    }

    public void TestMat()
    {
        _cube1.GetComponent<Renderer>().material = _blue;
    }
}
