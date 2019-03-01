using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{

    public void Start()
    {
        GetComponent<Animator>().Play("Welcome");
    }

    public void FadeAD()
    {
        GetComponent<Animator>().Play("FadeInSlow");
    }

    public void FadeJump()
    {
        GetComponent<Animator>().Play("FadeInJump");
    }
}
