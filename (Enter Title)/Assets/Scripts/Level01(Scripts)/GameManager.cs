using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool[] arr = new bool[15];
    public GameObject _levelManager;

    public Material _levelComplete;

    public GameObject[] _levelCubes;

    private void Update()
    {
        if(Finish._levelFinished[0] == true)
        {
            _levelManager.GetComponent<Animator>().Play("Level2Anim");
            _levelCubes[0].GetComponent<Renderer>().material = _levelComplete;
        }
    }



}
