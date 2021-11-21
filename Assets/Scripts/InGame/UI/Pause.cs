using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
