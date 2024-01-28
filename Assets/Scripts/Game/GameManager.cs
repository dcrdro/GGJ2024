using Core;
using System.Collections;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] levels;
    public float[] cameraSizes;

    public Transform container;

    int level;

    public int debugLevel = -1;

    public bool GameOver { get; private set; }

    private void Start()
    {
        Time.timeScale = 1;
        level = debugLevel != -1 ? debugLevel : Mathf.Clamp(PlayerPrefs.GetInt("Level", 0), 0, levels.Length);
        var instance = Instantiate(levels[level]);
        Camera.main.orthographicSize = cameraSizes[level];
        instance.transform.parent = container;
        
        EnemiesDiedCounter.Instance.Initialize();
        JewelsCounter.Instance.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver)
        {
            if (EnemySpawnPointsContainer.Instance.EscapedCount >= EnemySpawnPointsContainer.Instance.Length &&
                JewelsContainer.Instance.Length <= 0)
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
                
                level = Mathf.Clamp(level + 1, 0, levels.Length - 1);
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
