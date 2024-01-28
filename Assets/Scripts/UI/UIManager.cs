using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    public GameObject trapRender;

    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject pausePanel;

    private void Awake() => 
        Instance = this;

    public void ShowWin() => winPanel.SetActive(true);
    public void ShowLose() => losePanel.SetActive(true);
    public void ShowPause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
}
