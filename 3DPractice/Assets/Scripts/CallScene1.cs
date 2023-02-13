using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallScene1 : MonoBehaviour
{
    // Start is called before the first frame update

    public void CallSplashScene()
    {
        SceneManager.LoadScene("Copy_SampleScene");
    }
}
