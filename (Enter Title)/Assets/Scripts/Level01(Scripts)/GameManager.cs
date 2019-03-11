using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool[] arr = new bool[15];
    public GameObject _levelManager;

    public Material _levelComplete;

    public GameObject[] _levelCubes;

    public Canvas _pauseCanvas;
    private bool _canOn = true;

    private void Update()
    {
        if(Finish._levelFinished[0] == true)
        {
            _levelManager.GetComponent<Animator>().Play("Level2Anim");
            _levelCubes[0].GetComponent<Renderer>().material = _levelComplete;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && _canOn == true)
        {
            Time.timeScale = 0;
            _pauseCanvas.enabled = true;
            _canOn = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && _canOn == false)
        {
            Time.timeScale = 1;
            _pauseCanvas.enabled = false;
            _canOn = true;
        }
    }



}
