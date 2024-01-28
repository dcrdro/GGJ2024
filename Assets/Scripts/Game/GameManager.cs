using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Serializable] 
    public class Config
    {
        public GameObject levels;
        public float cameraSize;
        public TrapType[] startTypes;
    }

    public Transform container;
    public Config[] configs;

    int level;

    public int debugLevel = -1;

    public bool GameOver { get; private set; }

    private void Start()
    {
        Time.timeScale = 1;
        level = debugLevel != -1 ? debugLevel : Mathf.Clamp(PlayerPrefs.GetInt("Level", 0), 0, configs.Length);
        var config = configs[level];
        var instance = Instantiate(config.levels);
        Camera.main.orthographicSize = config.cameraSize;
        instance.transform.parent = container;
        var traps = config.startTypes;

        FindObjectOfType<TrapManager>().Init(traps);
        
        EnemiesDiedCounter.Instance.Initialize();
        JewelsCounter.Instance.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            if (JewelsContainer.Instance.StolenCount >= JewelsContainer.Instance.initcount)
            {
                GameOver = true;
                Time.timeScale = 0;
                FindObjectOfType<UIManager>().ShowLose();
                FindObjectOfType<AudioManager>().PlayLose();

            }

            if (EnemySpawnPointsContainer.Instance.EscapedCount >= EnemySpawnPointsContainer.Instance.Length &&
                JewelsContainer.Instance.Length > 0)
            {
                GameOver = true;
                Time.timeScale = 0;
                FindObjectOfType<UIManager>().ShowWin();
                FindObjectOfType<AudioManager>().PlayWin();
                
                level = Mathf.Clamp(level + 1, 0, configs.Length - 1);
                PlayerPrefs.SetInt("Level", level);
            }
        }
    }

    public void OpenMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void Restart() => SceneManager.LoadScene(1);
    public void Continue() => SceneManager.LoadScene(1);
    public void Exit() => Application.Quit();
    public void Pause() => Time.timeScale = 0;
    public void Clear() => PlayerPrefs.DeleteAll();
    public void Resume()
    {
        UIManager.Instance.pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
