using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void Button()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }
}
