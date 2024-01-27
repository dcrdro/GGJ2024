using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool GameOver { get; private set; }

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
            }
        }
    }

    public void OpenMenu() => SceneManager.LoadScene(0);
    public void Restart() => SceneManager.LoadScene(1);
    public void Continue() => SceneManager.LoadScene(1);
    public void Exit() => Application.Quit();
}
