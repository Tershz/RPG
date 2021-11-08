using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
