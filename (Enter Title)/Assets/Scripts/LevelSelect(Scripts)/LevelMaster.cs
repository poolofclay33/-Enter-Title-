using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMaster : MonoBehaviour
{
    public Material _yellow;
    public Canvas _canvas;

    public GameObject _cube1;
    public GameObject _playerCube;

    public GameObject _loadingScreen;
    public Slider _slider;

    public GameObject _gameManager;

    AsyncOperation async;

    private Animator _anim;

    public GameObject[] _trails;
    public GameObject[] _levels;

    public Material _levelCompletedMat;
    public Material _levelCubes;

    private void Start()
    {
        if(ES3.KeyExists("Level01") == true)
        {
            Debug.Log("EXISTS");
            _trails[0].SetActive(true);
            Load();
        }

        if(Finish._level1Done == true)
        {
            _trails[0].GetComponent<MeshRenderer>().enabled = true;
        }

        _canvas.GetComponent<Animator>().Play("FadeInLevelSelect");
        _playerCube.GetComponent<TestMove>().enabled = false;
        StartCoroutine("Wait");

        _anim = GetComponent<Animator>();
    }

    public void Load()
    {
        _playerCube.transform.position = ES3.Load<Vector3>("cubePosition");
        //_playerCube.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
    }

    public void Save()
    {
        ES3.Save<Vector3>("cubePosition", _playerCube.transform.position);

        //PlayerPrefs.SetFloat("PlayerX", _playerCube.transform.position.x);
        //PlayerPrefs.SetFloat("PlayerY", _playerCube.transform.position.y);
        //PlayerPrefs.SetFloat("PlayerZ", _playerCube.transform.position.z);
    }

    IEnumerator LoadingScreen()
    {
        _loadingScreen.SetActive(true);
        async = SceneManager.LoadSceneAsync(0);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            _slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                _slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    private bool _firstAnimDone = false;

    public void Test()
    {
        _levels[0].GetComponent<Renderer>().material = _levelCompletedMat;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);

        if (ES3.KeyExists("Level01") == true)
        {
            bool myBool = ES3.Load<bool>("Level01");
            GetComponent<Animator>().Play("Level01Completed");
            yield return new WaitForSeconds(1f);
            Test();
            yield return new WaitForSeconds(2f);
            GetComponent<Animator>().Play("Level2Anim");
            yield return new WaitForSeconds(4.5f);
        }
        else 
        {
            GetComponent<Animator>().Play("BeginLevelSelect");
            yield return new WaitForSeconds(3f);
            _levels[0].GetComponent<Renderer>().material = _levelCubes;
            _firstAnimDone = true;
        }
        _playerCube.GetComponent<TestMove>().enabled = true;
    }

    IEnumerator FadeScene()
    {
        yield return new WaitForSeconds(0.75f);
        _canvas.GetComponent<Animator>().Play("FadeScene");
        yield return new WaitForSeconds(3f);

        //StartCoroutine("LoadingScreen");

        Save();

        SceneManager.LoadScene("Level01");
    }

    public void Level1()
    {
        GetComponent<Animator>().enabled = false;

        _levels[0].GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("FadeScene");
    }
}
