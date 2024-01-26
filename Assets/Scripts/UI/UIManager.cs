using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject trapRender;

    public GameObject winPanel;
    public GameObject losePanel;

    public void ShowWin() => winPanel.SetActive(true);
    public void ShowLose() => losePanel.SetActive(true);
}
