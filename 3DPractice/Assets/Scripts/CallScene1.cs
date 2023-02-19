using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CallScene1 : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI progressText;
    // Start is called before the first frame update
    public float finalTime = 2f;
    private float timer = 0f;
    public bool startUpdate = false;
    public void CallSplashScene(int NextScene)
    {
        slider.gameObject.SetActive(true);
        startUpdate = true;

    }
    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (!startUpdate) return;
        timer += Time.deltaTime;
        if(timer < finalTime)
        {
            float progress = Mathf.Min(timer / finalTime , 1f);
            Debug.Log(progress);
            slider.value = progress;
            progressText.text = (int)(progress * 100f) + "%";
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
   
}
