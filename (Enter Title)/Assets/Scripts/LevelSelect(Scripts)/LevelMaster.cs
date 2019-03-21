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

    //private bool _level1Done = false;
    //private bool _level2Done = false;
    //private bool _level3Done = false;

    public static bool[] _levelDone = new bool[15];

    private void Start()
    {
        if(_levelDone[0] == true)
        {
            _levels[0].GetComponent<Renderer>().material = _levelCompletedMat;
        }

        if(_levelDone[1] == true)
        {
            _levels[1].GetComponent<Renderer>().material = _levelCompletedMat;
        }

        if (_levelDone[2] == true)
        {
            _levels[2].GetComponent<Renderer>().material = _levelCompletedMat;
        }

        if (_levelDone[3] == true)
        {
            _levels[3].GetComponent<Renderer>().material = _levelCompletedMat;
        }

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

        if (ES3.KeyExists("Level04") == true)
        {
            _trails[3].SetActive(true);
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
            _levelDone[0] = true;
        }
        else if(i == 2)
        {
            _levels[1].GetComponent<Renderer>().material = _levelCompletedMat;
            _levelDone[1] = true;
        }
        else if(i == 3)
        {
            _levels[2].GetComponent<Renderer>().material = _levelCompletedMat;
            _levelDone[2] = true;
        }
        else if (i == 4)
        {
            _levels[3].GetComponent<Renderer>().material = _levelCompletedMat;
            _levelDone[3] = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);

        if (ES3.KeyExists("Level01") == true && ES3.KeyExists("Level02") == false)
        {
            Debug.Log("LEVEL 1 KEY");
            bool myBool = ES3.Load<bool>("Level01");
            _anim.Play("Level01Completed");
            yield return new WaitForSeconds(1f);
            Test(1);
            yield return new WaitForSeconds(2f);
            _anim.Play("Level2Anim");
            yield return new WaitForSeconds(3f);
            _levels[1].GetComponent<Renderer>().material = _levelCubes;
        }

        else if (ES3.KeyExists("Level02") == true && ES3.KeyExists("Level03") == false)
        {
            Debug.Log("LEVEL 2 KEY");
            bool myBool = ES3.Load<bool>("Level02");
            _anim.Play("Level02Completed");
            yield return new WaitForSeconds(1f);
            Test(2);
            yield return new WaitForSeconds(2f);
            _anim.Play("Level3Anim");
            yield return new WaitForSeconds(3f);
            _levels[2].GetComponent<Renderer>().material = _levelCubes;
        }

        else if (ES3.KeyExists("Level03") == true && ES3.KeyExists("Level04") == false)
        {
            Debug.Log("LEVEL 3 KEY");
            bool myBool = ES3.Load<bool>("Level03");
            _anim.Play("Level03Completed");
            yield return new WaitForSeconds(1f);
            Test(3);
            yield return new WaitForSeconds(2f);
            _anim.Play("Level4Anim");
            yield return new WaitForSeconds(3f);
            _levels[3].GetComponent<Renderer>().material = _levelCubes;
        }

        else if (ES3.KeyExists("Level04") == true && ES3.KeyExists("Level05") == false)
        {
            Debug.Log("LEVEL 4 KEY");
            bool myBool = ES3.Load<bool>("Level04");
            _anim.Play("Level04Completed");
            yield return new WaitForSeconds(1f);
            Test(3);
            yield return new WaitForSeconds(2f);
            _anim.Play("Level5Anim");
            yield return new WaitForSeconds(3f);
            _levels[3].GetComponent<Renderer>().material = _levelCubes;
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

    IEnumerator Level4FLoad()
    {
        yield return new WaitForSeconds(0.75f);
        _canvas.GetComponent<Animator>().Play("FadeScene");
        yield return new WaitForSeconds(3f);

        //StartCoroutine("LoadingScreen");

        Save();

        SceneManager.LoadScene("Level04");
    }

    public void Level1()
    {
        _anim.enabled = false;

        _levels[0].GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("FadeScene");
    }

    public void Level2()
    {
        _anim.enabled = false;

        _levels[1].GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("Level2FLoad");
    }

    public void Level3()
    {
        _anim.enabled = false;

        _levels[2].GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("Level3FLoad");
    }

    public void Level4()
    {
        _anim.enabled = false;

        _levels[3].GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("Level4FLoad");
    }
}
