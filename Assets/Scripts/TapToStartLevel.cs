using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartLevel : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }
    public void StartLevel()
    {
        Time.timeScale = 1f;
        transform.parent.gameObject.SetActive(false);
    }
}
