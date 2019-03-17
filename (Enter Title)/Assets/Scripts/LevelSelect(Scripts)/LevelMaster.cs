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
        if (ES3.KeyExists("Level01") == true)
        {
            _trails[0].SetActive(true);
            Load();
        }

        if (ES3.KeyExists("Level02") == true)
        {
            _trails[1].SetActive(true);
            Load();
        }

        if (ES3.KeyExists("Level03") == true)
        {
            _trails[2].SetActive(true);
            Load();
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

    public void Test(int i)
    {
        if(i == 1)
        {
            _levels[0].GetComponent<Renderer>().material = _levelCompletedMat;
        }
        if(i == 2)
        {
            _levels[1].GetComponent<Renderer>().material = _levelCompletedMat;
        }
        if(i == 3)
        {
            _levels[2].GetComponent<Renderer>().material = _levelCompletedMat;
        }
    }

    private bool _level1Done = false;
    private bool _level2Done = false;
    private bool _level3Done = false;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);

        if (ES3.KeyExists("Level01") == true && _level1Done == false)
        {
            Debug.Log("LEVEL 1 KEY");
            bool myBool = ES3.Load<bool>("Level01");
            GetComponent<Animator>().Play("Level01Completed");
            yield return new WaitForSeconds(1f);
            Test(1);
            yield return new WaitForSeconds(2f);
            GetComponent<Animator>().Play("Level2Anim");
            yield return new WaitForSeconds(3f);
            _levels[1].GetComponent<Renderer>().material = _levelCubes;
            _level1Done = true;
        }

        else if (ES3.KeyExists("Level02") == true && _level2Done == false)
        {
            Debug.Log("LEVEL 2 KEY");
            bool myBool = ES3.Load<bool>("Level02");
            GetComponent<Animator>().Play("Level02Completed");
            yield return new WaitForSeconds(1f);
            Test(2);
            yield return new WaitForSeconds(2f);
            GetComponent<Animator>().Play("Level3Anim");
            yield return new WaitForSeconds(3f);
            _levels[2].GetComponent<Renderer>().material = _levelCubes;
            _level2Done = true;
        }

        else if (ES3.KeyExists("Level03") == true && _level3Done == false)
        {
            Debug.Log("LEVEL 3 KEY");
            bool myBool = ES3.Load<bool>("Level03");
            GetComponent<Animator>().Play("Level03Completed");
            yield return new WaitForSeconds(1f);
            Test(3);
            yield return new WaitForSeconds(2f);
            GetComponent<Animator>().Play("Level4Anim");
            yield return new WaitForSeconds(3f);
            _levels[3].GetComponent<Renderer>().material = _levelCubes;
            _level3Done = true;
        }

        else 
        {
            Debug.Log(":(");
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

    IEnumerator Level2FLoad()
    {
        yield return new WaitForSeconds(0.75f);
        _canvas.GetComponent<Animator>().Play("FadeScene");
        yield return new WaitForSeconds(3f);

        //StartCoroutine("LoadingScreen");

        Save();

        SceneManager.LoadScene("Level02");
    }

    IEnumerator Level3FLoad()
    {
        yield return new WaitForSeconds(0.75f);
        _canvas.GetComponent<Animator>().Play("FadeScene");
        yield return new WaitForSeconds(3f);

        //StartCoroutine("LoadingScreen");

        Save();

        SceneManager.LoadScene("Level03");
    }

    public void Level1()
    {
        GetComponent<Animator>().enabled = false;

        _levels[0].GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("FadeScene");
    }

    public void Level2()
    {
        GetComponent<Animator>().enabled = false;

        _levels[1].GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("Level2FLoad");
    }

    public void Level3()
    {
        GetComponent<Animator>().enabled = false;

        _levels[1].GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("Level3FLoad");
    }
}
