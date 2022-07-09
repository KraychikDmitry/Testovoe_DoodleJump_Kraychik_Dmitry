using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnClick(string SceneName)
    {
        if (SceneName == "Level")
            Time.timeScale = 0f;
        SceneManager.LoadScene(SceneName);
    }
}
