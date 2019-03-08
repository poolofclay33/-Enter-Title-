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

    AsyncOperation async;

    private void Start()
    {
        _canvas.GetComponent<Animator>().Play("FadeInLevelSelect");
        _playerCube.GetComponent<LevelSelectCube>().enabled = false;
        StartCoroutine("Wait");
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().Play("BeginLevelSelect");
        yield return new WaitForSeconds(4.5f);
        _playerCube.GetComponent<LevelSelectCube>().enabled = true;
    }

    IEnumerator FadeScene()
    {
        yield return new WaitForSeconds(0.75f);
        _canvas.GetComponent<Animator>().Play("FadeScene");
        yield return new WaitForSeconds(3f);

        //StartCoroutine("LoadingScreen");

        SceneManager.LoadScene("Level01");
    }

    public void Level1()
    {
        GetComponent<Animator>().enabled = false;

        _cube1.GetComponent<Renderer>().material = _yellow;

        //_cube1.GetComponentInChildren<ParticleSystem>().Play();

        StartCoroutine("FadeScene");
    }
}
