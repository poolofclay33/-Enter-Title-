using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCanvas : MonoBehaviour
{
    public GameObject _door;

    public void Start()
    {
        GetComponent<Animator>().Play("FadeStartingLevel");

        StartCoroutine("Wait");
    }

    public void FadeAD()
    {
        GetComponent<Animator>().Play("FadeInSlow");
    }

    public void FadeJump()
    {
        GetComponent<Animator>().Play("FadeInJump");
    }

    public void CloseDoor()
    {
        _door.GetComponent<Animator>().Play("CloseDoor(Tutorial)");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Animator>().Play("Welcome");
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void FinishLevel()
    {
        GetComponent<Animator>().Play("FadeLevelCanvas");
        StartCoroutine("Wait4Anim");
    }

    IEnumerator Wait4Anim()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("LevelSelect");
    }
}
