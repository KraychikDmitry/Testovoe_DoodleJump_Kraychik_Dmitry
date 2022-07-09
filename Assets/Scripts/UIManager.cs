using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject tapToStartCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject buttonPause;

    public void TapToStartLevel()
    {
        Time.timeScale = 1f;
        tapToStartCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        buttonPause.SetActive(true);
    }

    public void ButtonPause()
    {
        pauseCanvas.SetActive(true);
        buttonPause.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ButtonResume()
    {
        pauseCanvas.SetActive(false);
        buttonPause.SetActive(true);
        Time.timeScale = 1f;
    }

    public void OpenGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        tapToStartCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        buttonPause.SetActive(false);
    }
}
