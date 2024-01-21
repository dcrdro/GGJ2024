
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Text title;
    public Text count;
    public Image icon;

    public ResourceType Type { get; set; }

    public void SetTitle(string name) => title.text = name;
    public void SetCount(int n) => count.text = $"x{n}";
    public void SetIcon(Sprite i) => icon.sprite = i;
}
